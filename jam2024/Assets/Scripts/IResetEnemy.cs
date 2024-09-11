using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResetEnemy
{
   public Vector3 ResetPosition { get; set; }
   public void Reset();
}

