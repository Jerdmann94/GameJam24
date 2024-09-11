using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public static List<AKillable> EnemyObjectList;
    public static List<AKillable> LoadedEnemies;
    public int maxLoadedEnemies;
    private void Start()
    {
        EnemyObjectList = new List<AKillable>();
        LoadedEnemies = new List<AKillable>();
    }

    private void FixedUpdate()
    {
        if (!GameMaster.GameRunning) return;
        if (LoadedEnemies.Count >= maxLoadedEnemies)
        {
            UnloadFarthestEnemies();
        }
    }

    private void UnloadFarthestEnemies()
    {
        throw new NotImplementedException();
    }

    public static void ResetEnemies()
    {
        //sort list into two lists, one for groundEnemies and one for flyingEnemies
        foreach (var o in EnemyObjectList)
        {
            o.Reset();
        }

        
    }
}
