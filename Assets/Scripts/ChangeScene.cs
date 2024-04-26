using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   //creating a custom function for changing the scene from the GameStart menu to the GamePlay scene
   public void ChangeTheScene (int sceneID)
    {
        //calling the Loadscene function from the scenemanager class. This allows us to move to the scene using its sceneID
        SceneManager.LoadScene (sceneID);
    }

    //another custom function that allows the player to exit the game when they click the quit button
    public void ExitGame()
    {
        Application.Quit ();
    }
}
