using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    //A public integer that is the actual countdown time. We'll -1 each second
    public int countdownTime;
    //Need a text variable for the display of the countdown time
    public TextMeshProUGUI displayTime;

    //Calling the corutine under the start function
    private void Start()
    {
        StartCoroutine(countdownStart());
    }
    IEnumerator countdownStart()
    {
    //storing the countdow in a while loop so that the coroutine restarts again while the statement time>0 is true
        while(countdownTime > 0)
        {
            //Using ToString() to store the integer variable in the text UI
            displayTime.text = countdownTime.ToString();
    //yield return allows the coroutine to start up again every second
            yield return new WaitForSeconds(1f);
    //-- means -1. We are decreasing the countdown time value every second
            countdownTime--;
        }
        //Adding a text that indicates the game has started
        displayTime.text = "Game Awn!";
    //Need to ensure that the gameStart text remains invisible after the countdown has ended
        yield return new WaitForSeconds(1f);
        displayTime.gameObject.SetActive(false);
    }


}
