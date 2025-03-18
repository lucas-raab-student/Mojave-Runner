using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Make sure this is assigned in the Inspector
    public float timeToSpawn;
    public GameObject[] obstacleInstances;
    public int numberOfInstances = 10;
    public int instanceIndex = 0;
    public float spawnTimeMax;
    public float spawnTimeMin;
    // Start is called before the first frame update
    void Start()
    {
        // Set a random time between 1 and 2 seconds to spawn the first obstacle
        timeToSpawn = Random.Range(spawnTimeMin, spawnTimeMax);
        obstacleInstances = new GameObject[numberOfInstances];
        for(int i = 0; i < obstacleInstances.Length; i++)
        {
            obstacleInstances[i]= Instantiate(obstaclePrefab);
            obstacleInstances[i].transform.position = transform.position;
            obstacleInstances[i].SetActive(false);
        }

        // Check if obstaclePrefab is not null
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle Prefab is not assigned in the Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure the obstaclePrefab is valid before attempting to spawn
        if (obstaclePrefab != null)
        {
            // Countdown the time to spawn
            timeToSpawn -= Time.deltaTime;

            // When timeToSpawn reaches 0 or less, spawn an obstacle
            if (timeToSpawn <= 0f)
            {
                SpawnObstacle();

                // Reset the spawn time to a random value between 1 and 2 seconds
                timeToSpawn = Random.Range(spawnTimeMin, spawnTimeMax);
            }
        }
        else
        {
            Debug.LogWarning("Obstacle Prefab is missing, unable to spawn obstacles.");
        }
    }

    // Function to spawn the obstacle at the spawner's position
    void SpawnObstacle()
    {
        obstacleInstances[instanceIndex].SetActive(true);
        instanceIndex++;
        obstacleInstances[instanceIndex].transform.position = transform.position;   
        if (instanceIndex == numberOfInstances) instanceIndex = 0;
   

    }
}
