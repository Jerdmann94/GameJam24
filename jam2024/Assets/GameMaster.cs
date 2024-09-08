using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool GameRunning = false;
    void Start()
    {
        //THIS NEEDS TO BE CHANGED LATER FOR WHEN THE PLAYER PRESSES START GAME
        GameRunning = true;
    }

    public static void RestartGame()
    {
        
    }
}
