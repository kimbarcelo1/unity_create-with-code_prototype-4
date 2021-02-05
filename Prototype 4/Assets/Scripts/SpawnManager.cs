using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateRandomPosition()
    {
        float randomXPosition = Random.Range(-spawnRange, spawnRange);
        float randomZPosition = Random.Range(-spawnRange, spawnRange);

        //Vector3 randomPosition = new Vector3(randomXPosition, 0, randomZPosition);

        return new Vector3(randomXPosition, 0, randomZPosition);
    }
}
