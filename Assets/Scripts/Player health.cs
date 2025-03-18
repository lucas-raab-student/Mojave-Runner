using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public int healthAmount = 3;
    public void TakeDamage(int amount)
    {
        healthAmount -= amount;
        GameFeel.AddCameraShake(0.1f);
        if (healthAmount <= 0)
        {
            GameManager.Instance.Restart();
        }
    }
    public static void TryDamageTarget(GameObject target, int damageAmount)
    {
        Playerhealth targetHealth = target.GetComponent<Playerhealth>();
        if(targetHealth) {
            targetHealth.TakeDamage(damageAmount);

        }
    }
}
