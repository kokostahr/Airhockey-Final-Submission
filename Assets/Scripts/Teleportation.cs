using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public bool isTeleporterL; //Will be false for RTeleporter
    public Transform TeleporterR;

    public SpawnPortal spawnPortal;

    GameObject puck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            puck = collision.gameObject;
            Teleport(collision.gameObject);
        }
    }

    void Teleport(GameObject puck)
    {
        //Teleport the puck to the other teleporter
        if (isTeleporterL)
        {
           
            puck.transform.position = TeleporterR.transform.position;

            GameObject.Find("Portals").GetComponent<SpawnPortal>().Start();
            Destroy(this.gameObject, 2f);

            //Invoke("spawnPortal.SpawnNewPortal", 30f);
            //GameObject.Find("Portals").GetComponent<SpawnPortal>().SpawnNewPortal();
           
        }
        else if (!isTeleporterL)
        {
            puck.transform.position = transform.position;
        }

       // Invoke("spawnPortal.SpawnNewPortal", 5f);
       // Destroy(this.gameObject, 15f);

        
        //GameObject.Find("Portals").GetComponent<SpawnPortal>().SpawnNewPortal();
    }

    /* public float activeTime = 20f;
     public float respawnTime = 30f;

     bool isActive = true;
     float timer = 0f;


     void Update()
     {
         if (isActive)
         {
             timer += Time.deltaTime;
             if (timer >= activeTime)
             {
                 Die();
             }
         }
         else
         {
             timer += Time.deltaTime;
             if (timer >= respawnTime) 
             {
                 Respawn();
             }
         }
     }

     void Die()
     {
         isActive = false;
         timer = 0f;
     }

     void Respawn()
     {
         isActive = true;
         timer = 0f;
     }*/

    // [SerializeField] GameObject teleporterL, teleporterR;
    //Vector2 entryPos;

    /*  public void TeleportPuck(ref Vector2 puckPosition, Vector2 puckVelocity, Vector2 fieldDimensions, float teleportSlotYMin, float teleportSlotYMax)
      {
          if (puckPosition.x < 0 && puckPosition.y >= teleportSlotYMin && puckPosition.y <= teleportSlotYMax)
          {
              puckPosition.x = fieldDimensions.x;
              fieldDimensions = teleporterL.transform.position;
              puckVelocity.velocity =
          }
          else if (puckPosition.x > fieldDimensions.x && puckPosition.y >= teleportSlotYMin && puckPosition.y <= teleportSlotYMax)
          {
              puckPosition.x = fieldDimensions.x;
              fieldDimensions = teleporterR.transform.position;
          }
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
          if(other.tag == "Puck")
          {
              TeleportPuck();
          }
      }*/


    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.gameObject.CompareTag("Puck"))
          {
              puck = collision.gameObject;
              entryPos = puck.transform.position;
              Teleport();
          }
      }

      void Teleport()
      {
          Teleporter
      }
      */

}
