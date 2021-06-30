using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;


    void Update()
    {
        if(Time.time > spawnTime){
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomY;
        float randomX;
        float randomVal = Random.Range(0, 10);

        if(randomVal >= 6){
            randomY = maxY;
        }else{
            randomY = minY;
        }
        
        randomX = Random.Range(minX, maxX);
        

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
