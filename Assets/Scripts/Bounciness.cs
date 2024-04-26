using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness : MonoBehaviour
{
    //Referencing my previous PuckMovement script incase I want to do any cool features that increase the speed, relating to how the puck bounces around
    public PuckMovement1 puckMovement;
    //Referencing my new ScoreTally script
    public ScoreTally scoreTally;
    //public float hitRestrict = 1;
    //A bool that will be used to check who hit the puck last
   // public bool lastPlayerHit;
    

    //Creating a function where I will work on the way in which the puck bounces/moves according to how it was hit by the paddle. 
    //Using collision to determine the puck position + paddle position and height
    void Bouncy(Collision2D collision)
    {
        //Need to find the position of the puck on the airhkey table
        Vector3 puckPosition = transform.position;
        //Need to find the position of the paddle when it collides with the puck
        Vector3 paddlePosition = collision.transform.position;
        //Need to find which part of the paddle the puck collided with
        float paddleHeight = collision.collider.bounds.size.y;

        //also need to identify which paddle the puck came into contact with, use an if statment to see which paddle it came into contact with
        float positionOnX;
         if(collision.gameObject.name == "Paddle 2")
        {
            positionOnX = -1; //to the left
        }
        else
        {
            positionOnX = 1; //to the right
        }
         //then we look for the part that the puck collided with on the y-axis of the paddle
        float positionOnY = puckPosition.y - paddlePosition.y / paddleHeight;
        //calling the movement system from the 'PuckMovement' script, so that the idetification of the paddle and puck position works within PuckMovement
        puckMovement.PuckMoves(new Vector2 (positionOnY, positionOnX));

    }
    //Need to ensure that custom function 'Bounce' is called whenever the puck collides with the paddles. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log($"####{collision.gameObject.name} -- {collision.gameObject.tag}");


        //Need to ensure that when the puck hits either paddle, it will move.
        if (collision.gameObject.name == "Paddle 1" || collision.gameObject.name == "Paddle 2")
        {
            //Calling the bouncy function simply.
            Bouncy(collision);
        }
        //using else if statements to check if the puck collided with the left barrier for player 1's point
        else if (collision.gameObject.name == "Left Goal")
        {
            scoreTally.PlayerWanGoal();
            //Setting the playerWanStart variable from 'PuckMovement' to false, as player 1 scored the point, so player 2 should start the next round
            puckMovement.playerWanStart = false;
            //Calling the 'Begin' Coroutine to check and process the ifstatment stored within it
            StartCoroutine(puckMovement.Begin());
            Debug.Log(collision.gameObject.name);
        }
        //doing the same thing for player 2's goal
        else if (collision.gameObject.name == "Right Goal")
        {
            scoreTally.PlayerTooGoal();
            puckMovement.playerWanStart = true;
            StartCoroutine(puckMovement.Begin());
        }
    }
}

/* private void OnTriggerEnter2D(Collider2D collision)
   {
       //Trying to use the bonus tag to give players points. I hope it works
       if (collision.gameObject.CompareTag("Bonus"))
       {
           //these dont work. why Not!!!
           if (collision.gameObject.name == "Paddle 1")
           {
               scoreTally.PlayerWanGoal();
           }
           else if (collision.gameObject.name == "Paddle 2")
           {
               scoreTally.PlayerTooGoal();
           }
           float delayTime = 0.5f;
           Destroy(collision.gameObject, delayTime);
       }
   }*/

/* private void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.gameObject.name == "Paddle 1")
     {
         collision.tag = "Bonus";
         scoreTally.PlayerWanGoal();
         float delayTime = 0.5f;
         Destroy(collision.gameObject, delayTime);
         Debug.Log("Bonus for Wan");
     }
 }

 //Setting up the bonus points system. The puck movement will also speed up when it travels through a bonus point. 
 /* private void OnTriggerEnter2D(Collider2D collision)
 {
  //Puck speeds up when it travels through bonus point. The player who hit the paddle last gains a point
  if (collision.tag == "Bonus" && collision.gameObject.name == "Paddle 1")
  {
      //Need assistance, the puck isn't speeding up when it passes through the bonus
      /*puckSpeed = extraSpeed;
      extraSpeed = startSpeed + 3f;
      //Here i tried to write code that links to the player that hit the paddle last, and would give an extra point if the puck passes through the Bonus
      //But I am scared thst the paddles may get deleted too, as I want the bonus point region to disappear after the puck has passed through. 
      scoreTally.PlayerWanGoal();
      float delayTime = 0.5f;
      Destroy(collision.gameObject, delayTime);

      Debug.Log("Bonus for Wan");
  }
 else if(collision.tag == "Bonus" && collision.gameObject.name == "Paddle 2")
  {
      scoreTally.PlayerTooGoal();
      float delayedTime = 0.5f;
      Destroy(collision.gameObject, delayedTime);
      Debug.Log("Bonus for Too");
*/



