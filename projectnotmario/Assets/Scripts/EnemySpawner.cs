using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minInterval = 1f;
    public float maxInterval = 3f;
    public float minSpawnX = 0f;
    public float maxSpawnX = 3f;

    private void Start()
    {
        // Start spawning immediately and repeat with random intervals
        Invoke("SpawnPrefab", Random.Range(minInterval, maxInterval));
    }

    private void SpawnPrefab()
    {
        float randomX = Random.Range(minSpawnX, maxSpawnX);
        Vector3 spawnLocation = new Vector3(randomX, transform.position.y, transform.position.z);

        // Instantiate the prefab at the current position of the spawner
        Instantiate(prefabToSpawn, spawnLocation, transform.rotation);

        // Schedule the next spawn
        Invoke("SpawnPrefab", Random.Range(minInterval, maxInterval));
    }
}
