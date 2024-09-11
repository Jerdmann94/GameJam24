using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public static List<AKillable> EnemyObjectList;

    private void Start()
    {
        EnemyObjectList = new List<AKillable>();
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
