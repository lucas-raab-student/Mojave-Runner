using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeel : MonoBehaviour
{public static GameFeel instance;
    public float CameraShakeTime = 0f;
    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }
    // Start is called before the first frame update
 public static void AddCameraShake(float time)
    {
        if(instance)
        {
            instance.CameraShakeTime = time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraShakeTime > 0f)
        {
            CameraShakeTime -= Time.deltaTime;
            Vector3 newCameraPosition = new Vector3();
            newCameraPosition.x = Random.Range(-0.1f, 0.1f);
            newCameraPosition.y= Random.Range(-0.1f, 0.1f);
            newCameraPosition.z = -10;
            Camera.main.transform.position = newCameraPosition;

        }
    }
}
