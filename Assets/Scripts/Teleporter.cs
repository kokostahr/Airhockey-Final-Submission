using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //public static Teleporter Instance;
    // [SerializeField] GameObject thePuck, teleportR, teleportL;
    //public OtherTeleporter tp;

    public Transform destination;
    GameObject Puck;
    

    private void Awake()
    {
        Puck = GameObject.FindGameObjectWithTag("Puck");
        StartCoroutine(PortalBai());
       // tp = GameObject.FindGameObjectWithTag("TeleporterR").GetComponent<OtherTeleporter>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Puck"))
        {
            //destination.transform.position = tp.transform.position;
            if (Vector2.Distance(Puck.transform.position, transform.position) > 0.7f)
            {
                Puck.transform.position = destination.transform.position;
            }
        }
    }

    IEnumerator PortalBai()
    {
        yield return new WaitForSeconds(15f);
        DestroyPortal();
    }

    private void DestroyPortal()
    {
        Destroy(this.gameObject);
    }
}

