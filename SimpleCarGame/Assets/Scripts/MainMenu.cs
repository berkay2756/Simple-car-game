using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void startGame()
   {
       UnityEngine.SceneManagement.SceneManager.LoadScene("Scene01");
   }


   public void exitGame()
   {
       Application.Quit();
   }


}
