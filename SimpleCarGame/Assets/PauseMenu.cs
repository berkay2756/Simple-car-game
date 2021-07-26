using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        pausePanel.enabled = false;
    }
    public Canvas pausePanel;
    public Canvas speedCanvas;
    public void resumeGame()
    {
        pausePanel.enabled = false;
        speedCanvas.enabled = true;
    }

    public void pauseGame()
    {
        pausePanel.enabled = true;
    }
    
    public void exitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            pauseGame();
            speedCanvas.enabled = false;
        }
    }
}
