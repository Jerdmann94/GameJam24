using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool GameRunning = false;
    public GameObject uiPanel;
   
    public void GameStart()
    {
        GameRunning = true;
        uiPanel.SetActive(false);
    }
    public void RestartGame()
    {
        GameRunning = false;
        uiPanel.SetActive(true);
    }
}
