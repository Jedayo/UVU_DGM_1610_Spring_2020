using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 15;
    public int enemyCount;
    public int waveNumber = 1; // Parameter to control how many enemies are spawned
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); // Spawns enemy wave
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Spawns powerup
    }

    private Vector3 GenerateSpawnPosition () { // Creates a random spawn position and returns it
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
        }

    void SpawnEnemyWave(int enemiesToSpawn) { // Function to spawn enemies based on a parameter
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Calls spawn function
        }
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Variable to track how many enemies are currently alive
        if (enemyCount == 0) { // Indicates end of wave
            waveNumber++; // Increment number of enemies for next wave
            SpawnEnemyWave(waveNumber); // Spawn enemy wave
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Spawn a powerup
        }
    }
}
