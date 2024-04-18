using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;

    [SerializeField] private GameObject enemy;

    public float spawnTimer = 1.0f;


    void Update()
    {   
        if(spawnTimer <= 0){
            SpawnEnemy();
            spawnTimer = 1.0f;
        }
        else {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy(){
        int randomInt = Random.Range(0, spawners.Length);
        Transform randomSpawner = spawners[randomInt];
        Debug.Log(randomInt);

        Instantiate(enemy, randomSpawner.position, randomSpawner.rotation);
    }
}
