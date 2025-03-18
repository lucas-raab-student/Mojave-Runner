using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Playerhealth playerHealth; // Reference to the Health script
    public Image[] heartImages; // Array of heart images to represent health
    int health = 0;

    void Awake()
    {
        // Find the Health script in the scene if not already assigned
        if (!playerHealth)
        {
            playerHealth = FindObjectOfType<Playerhealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If playerHealth is not set, do nothing
        if (!playerHealth) return;

        // Only update health if it has changed
        if (health != playerHealth.healthAmount)
        {
            UpdateHealth();
        }
    }

    // Update the UI to match the player's health
    void UpdateHealth()
    {
        health = playerHealth.healthAmount;

        // Loop through the heart images and enable/disable based on health
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health)
                heartImages[i].enabled = true;  // Show the heart if i < health
            else
                heartImages[i].enabled = false; // Hide the heart if i >= health
        }
    }
}
