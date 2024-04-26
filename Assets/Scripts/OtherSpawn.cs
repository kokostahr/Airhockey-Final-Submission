using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSpawn : MonoBehaviour
{

    public GameObject newerPortal;
    public bool haltSpawning = false;
    public float spawnsTime;
    public float spawnsDelay;


    public void Start()
    {
        InvokeRepeating("SpawnAnothaPortal", spawnsTime, spawnsDelay);

    }
    public void SpawnAnothaPortal()
    {
        GameObject nrp = Instantiate(newerPortal, this.transform) as GameObject;
        nrp.transform.localPosition = new Vector3(Random.Range(-8.1f, 3.34f), -3.7f, 0);

        /* if (haltSpawning) //If its true
         {
             CancelInvoke("SpawnAnothaPortal");
         }
        Vector3 spawnPos = new Vector3(Random.Range(-8.1f, 3.34f), -3.7f, 0);
        Instantiate(newerPortal, spawnPos, Quaternion.identity);*/
    }
}
