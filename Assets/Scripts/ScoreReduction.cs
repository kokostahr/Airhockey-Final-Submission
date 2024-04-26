using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReduction : MonoBehaviour
{

    public void ReducePointsWan()
    {
        ScoreTally scoreTally = GetComponent<ScoreTally>();
        scoreTally.playerWanScore--;
        scoreTally.player1ScoreText.text = scoreTally.playerWanScore.ToString();
        scoreTally.CheckScore();
    }

    public void ReducePointsToo()
    {
        ScoreTally scoreTally = GetComponent<ScoreTally>();
        scoreTally.playerTooScore--;
        scoreTally.player2ScoreText.text = scoreTally.playerTooScore.ToString();
        scoreTally.CheckScore();
    }
}
