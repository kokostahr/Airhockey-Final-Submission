using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject puck;
    public float oppSpeed;
    float distance;
    Rigidbody2D rb;

    [SerializeField] private float multiplier = 1;
    [SerializeField] private ForceMode2D forceMode;

    public float distanceBetween;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public PuckMovement1 puckMovement;
    public ScoreTally scoreTally;
    public ScoreReduction scoreReduction;

    public int hitCounterToo = 0;
    public float resetTime = 2f;

    bool hasScored2 = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            if (!hasScored2)
            {
                hitCounterToo++;

                if (hitCounterToo > 1)
                {
                    ReductionPoints();
                    Invoke("ResetCounter", resetTime);
                    hasScored2 = true;
                }
            }
        }
    }

    void ResetCounter()
    {
        hitCounterToo = 0;
        hasScored2 = false;
    }

    void ReductionPoints()
    {
        if (scoreTally.playerTooScore > 0)
        {
            scoreReduction.ReducePointsToo();
        }
    }

    void Update()
    {
        //Geting the distance between the AIPaddle and the puck
        distance = Vector2.Distance(transform.position, puck.transform.position);
        //Setting the direction that the ai will move in. Making it rotate towards the puck
        Vector2 direction = puck.transform.position - transform.position;
        direction.Normalize();
         
        if(distance < distanceBetween)
        {
            //The AIPaddle will move towards the puck in a given position
            Vector2 between = puck.transform.position - transform.position;
            between.Normalize();

            rb.AddForce(between * multiplier, forceMode);
        }
        else
        {
            rb.Sleep();
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}


/*  void ResetAI()
  {
      //Don't want the AI to move unnecessarily, temporarily lock it in place using vector co-ordinates

      //The AI should move back to the its position after a goal is scored
      if(puckMovement.playerWanStart == true || puckMovement.playerWanStart == false)
      {
          rb.velocity = new Vector2(0, 0);
          transform.position = new Vector2(-6.23f, -0.25f);
      }

  }

  public IEnumerator Resetting()
  {
      ResetAI();
      yield return new WaitForSeconds(1);
  }*/