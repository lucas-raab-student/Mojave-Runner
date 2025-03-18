using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float JumpForce = 5.0f;
    public bool IsFalling = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component from the GameObject and store it in 'rb'
        rb = GetComponent<Rigidbody2D>();

        // Check if rb is null (for debugging purposes)
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on this GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
            // Check if the player presses the space bar
            if (!IsFalling&&Input.GetKeyDown(KeyCode.Space))
            {
                // Apply an upwards force to the Rigidbody2D
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); // Use Impulse instead of Force for jumps

            }
        
 
      
    }
   public void  OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            IsFalling=false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                IsFalling = true;
            }
        }

    }

}
