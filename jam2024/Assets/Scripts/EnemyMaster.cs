using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public static List<AKillable> EnemyObjectList;
    public static List<AKillable> LoadedEnemies;
    public int maxLoadedEnemies = 10;
    public GameObject player;
    private void Start()
    {
        EnemyObjectList = new List<AKillable>();
        LoadedEnemies = new List<AKillable>();
    }

    private void FixedUpdate()
    {
        if (!GameMaster.GameRunning) return;
        LoadCloseEnemies();
        if (LoadedEnemies.Count >= maxLoadedEnemies)
        {
            UnloadFarthestEnemies();
        }
    }

    private void LoadCloseEnemies()
    {
        var sortedList = new List<AKillable>();
        sortedList = EnemyObjectList
            .OrderBy(go => (go.transform.position - player.transform.position).sqrMagnitude)
            .ToList();
        var i = 0;
        foreach (var aKillable in sortedList)
        {
            i++;
            if (i >= maxLoadedEnemies) 
                aKillable.RespawnMe();
            else
                aKillable.KillMe();
            
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
