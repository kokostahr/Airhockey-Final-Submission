using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Had to add a textMeshPro UnityEngine, because Unity could not seeeee my text. BIG SIGh
public class ScoreTally : MonoBehaviour
{
    //need variables to keep track of each player's score. starts at 0, because...well both players start at 0 xD
    public int playerWanScore = 0;
    public int playerTooScore = 0;
    //next I need to link up the scores of each player to their texts
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    //Need a score limit that will end the game
    public int scoreLimit;

    

    //Now we need to link the passing of barriers to the score text.
    //Create custom function for the moments when player 1 scores a goal
    public void PlayerWanGoal()
    {
        //want to increase the score (++ means add 1)
        playerWanScore++;
        //Afterwards we need to update the text function when player 1 scores a goal.Using a string to pass the int into the text
        player1ScoreText.text = playerWanScore.ToString();
        //Then we call the checkScore function for whenever player1 scores a goal.
        CheckScore();
        
    }

    //Doing the same for player 2
    public void PlayerTooGoal()
    {
        playerTooScore++;
        player2ScoreText.text = playerTooScore.ToString();
        CheckScore();
    }
    //These 2 custom functions will be called in the Bounciness script.
    //A custom function to check if the players points are = to the score limit
    public void CheckScore()
    {
        //using an if statment to check if the points are equal?
        if(playerWanScore == scoreLimit ||  playerTooScore == scoreLimit)
        {
            //Using sceneManager to load sceneID 2 which is the game over scene
            SceneManager.LoadScene(2);
        }

        
    }
}
/*
     *   public void PlayerWanNegative()
    {
        playerWanScore--;
        player1ScoreText.text = playerWanScore.ToString();
        CheckScore();
    }

    public void PlayerTooNegative()
    {
        playerWanScore--;
        player1ScoreText.text = playerWanScore.ToString();
        CheckScore();
    }
     */