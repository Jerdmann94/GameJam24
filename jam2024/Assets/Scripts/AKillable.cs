using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class AKillable : MonoBehaviour, IResetEnemy
{
   private void Start()
   {
      if (EnemyMaster.EnemyObjectList!= null)
      {
         EnemyMaster.EnemyObjectList.Add(this);
      }
   }

   public void KillMe()
   {
      gameObject.GetComponent<Rigidbody2D>().simulated= false;
      gameObject.GetComponent<Collider2D>().enabled = false;
      gameObject.GetComponent<SpriteRenderer>().enabled = false;
   }

   public void RespawnMe()
   {
      gameObject.GetComponent<Rigidbody2D>().simulated = true;
      gameObject.GetComponent<Collider2D>().enabled = true;
      gameObject.GetComponent<SpriteRenderer>().enabled = true;
   }

   public abstract Vector3 ResetPosition { get; set; }
   public bool Loaded { get; set; }
   public abstract void Reset();
}
