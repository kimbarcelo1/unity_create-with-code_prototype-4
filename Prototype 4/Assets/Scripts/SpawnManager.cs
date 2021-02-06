using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    
    private float spawnRange = 9.0f;

    public int enemyCount;
    public int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveCount);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount <= 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
            SpawnPowerup();
        }
    }

    void SpawnEnemyWave(int numberOfEnemtToSpawn)
    {
        for(int i = 0; i < numberOfEnemtToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        float randomXPosition = Random.Range(-spawnRange, spawnRange);
        float randomZPosition = Random.Range(-spawnRange, spawnRange);

        //Vector3 randomPosition = new Vector3(randomXPosition, 0, randomZPosition);

        return new Vector3(randomXPosition, 0, randomZPosition);
    }
}
