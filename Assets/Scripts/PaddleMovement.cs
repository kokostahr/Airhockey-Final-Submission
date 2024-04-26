using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    //Creating a speed and vector for the player's paddle
    public float mouseSpeed = 30f;
    Vector3 mouseMovement;
    Rigidbody2D rb;

    public GameObject puck;
    public float maxX;
    public float minX;
    public float minY;
    public float maxY;

    public ScoreTally scoreTally;
    public ScoreReduction scoreReduction;
    
    public int hitCounterWan = 0;
    public float resetTime = 5f;

    bool hasScored1 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //We'll use the left click to activate the movement of the paddle
        if (Input.GetMouseButton(0))
        {
            Vector2 between = puck.transform.position - rb.transform.position;
            between.Normalize();
            rb.AddForce(between * mouseSpeed, ForceMode2D.Force);
            mouseMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Adding this line of code, so that the paddle does not move along z-axis
            mouseMovement.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, mouseMovement, mouseSpeed * Time.deltaTime);
           
        }
        //creating a vector3 called pos to restrict the paddle's movement
        //Using transform.position to firstly find the position of the paddle object on screen
        Vector3 pos = transform.position;
        //using mathf.clamp to clamp the movement between two x values 
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //then storing pos into transform again, so that the code can work!
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        { 
            if(!hasScored1)
            {
                hitCounterWan++;

                if (hitCounterWan > 1)
                {
                    ReducePoints();
                    Invoke("ResetCounter", resetTime);
                    hasScored1 = true;
                }
 
            } 
        }
    }

    void ResetCounter()
    {
        hitCounterWan = 0;
        hasScored1 = false;
    }
    
    void ReducePoints()
    {
        if (scoreTally.playerWanScore > 0)
        {
            scoreReduction.ReducePointsWan();
        }
    }
}

//scoreTally.playerWanScore--;

/* ScoreReduction ReducePoints = GetComponent<ScoreReduction>();
 if (ReducePoints != null)
 {
     ReducePoints.ReducePoints();
 }

 //ScoreReduction ReducePoints = GetComponent<ScoreReduction>();
 //ReducePoints.ReducePoints();*/