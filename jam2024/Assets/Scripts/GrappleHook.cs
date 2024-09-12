using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.Camera;

public class GrappleHook : MonoBehaviour
{
    [SerializeField] private LineRenderer rope;

    [SerializeField] LayerMask grappableMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappableSpeed = 10f;
    [SerializeField] float grappableShootSpeed = 20f;
    
    private Camera _camera1; 
    public DistanceJoint2D distanceJoint;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)main.ScreenToWorldPoint(Input.mousePosition);
            rope.SetPosition(0, mousePos);
            rope.SetPosition(1, transform.position);
            distanceJoint.connectedAnchor = mousePos;
            distanceJoint.enabled = true;
            rope.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            distanceJoint.enabled = false;
            rope.enabled = false;
        }

        if (distanceJoint.enabled)
        {
            rope.SetPosition(1, transform.position);
        }

    }
}
