using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ParlaxLayer;

public class Obstacle : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of the obstacle's horizontal movement
    private float screenWidth;   // Screen width for boundary detection
    public  Parallax.layer layer;
    public float endRange = -12f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the screen width in world units
        screenWidth = Camera.main.orthographicSize * 2 * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle left to right across the screen

        transform.position += Vector3.left * Parallax.GetSpeed(layer) * Time.deltaTime;  // Move obstacle to the left
        if (transform.position.x <= endRange)
        {
            gameObject.SetActive(false);
        }

       
    }
    private void OnTriggerEnter2D(Collider2D other )
    {
        Playerhealth.TryDamageTarget(other.gameObject,1);
    }
}
