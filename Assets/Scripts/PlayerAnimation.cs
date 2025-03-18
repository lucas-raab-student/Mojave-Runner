using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Player player;
    public Rigidbody2D rb2d;
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the YVelocity to the Rigidbody2D's velocity.y
        animator.SetFloat("YVelocity", rb2d.velocity.y);

        // Check if the player is falling
        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true); // Set Falling to true when falling
        }
        else
        {
            animator.SetBool("Falling", false); // Set Falling to false when not falling
        }
    }
    public void Smoke()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
    }
}
