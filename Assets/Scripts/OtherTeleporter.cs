using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherTeleporter : MonoBehaviour
{
    public static OtherTeleporter instance;

    public Transform destinationSion;
    GameObject Puck;
    Teleporter tp;

    private void Awake()
    {
        Puck = GameObject.FindGameObjectWithTag("Puck");
        StartCoroutine(PortalBai());
        //tp = GameObject.FindGameObjectWithTag("TeleporterL").GetComponent<Teleporter>();
        
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            destinationSion.transform.position = tp.transform.position;
            if (Vector2.Distance(Puck.transform.position, transform.position) > 0.7f)
            {
                Puck.transform.position = destinationSion.transform.position;
            }
        }
    }

    IEnumerator PortalBai()
    {
        yield return new WaitForSeconds(10f);
        DestroyPortal();
    }

    private void DestroyPortal()
    {
        Destroy(this.gameObject);
    }
}
