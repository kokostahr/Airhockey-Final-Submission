using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    public GameObject newPortal;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;


    public void Start()
    {
        InvokeRepeating("SpawnNewPortal", spawnTime, spawnDelay);
      
    }
    public void SpawnNewPortal()
    {
         GameObject np = Instantiate(newPortal, this.transform) as GameObject;
        np.transform.localPosition = new Vector3(Random.Range(-8.1f, 3.34f), 3.7f, 0);

        /*if (stopSpawning) //If its true
        {
            CancelInvoke("SpawnNewPortal");
        }
        Vector3 randomSpawnPos = new Vector3(Random.Range(-8.1f, 3.34f), 3.7f, 0);
        Instantiate(newPortal, randomSpawnPos, Quaternion.identity);*/

    }
}
//Random.Range(3.7f, -3.9f),,,,[Random.Range(0, newPortal.Length)