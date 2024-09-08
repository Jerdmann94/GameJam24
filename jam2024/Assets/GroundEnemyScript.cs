using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyScript : MonoBehaviour
{
    private Vector3 startPosition;
    public float range = 1;
    public float speed = 0.5f;
    public float edgeCheckDistance = 0.1f;
    public LayerMask groundLayer; 
    private Transform groundCheckLeft;
    private Transform groundCheckRight;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
         groundCheckLeft = new GameObject("GroundCheckLeft").transform;
        groundCheckRight = new GameObject("GroundCheckRight").transform;

        groundCheckLeft.parent = transform;
        groundCheckRight.parent = transform;

        groundCheckLeft.localPosition = new Vector3(-0.5f, -0.5f, 0); 
        groundCheckRight.localPosition = new Vector3(0.5f, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool isEdgeLeft = !Physics2D.Raycast(groundCheckLeft.position, Vector2.down, edgeCheckDistance, groundLayer);

        bool isEdgeRight = !Physics2D.Raycast(groundCheckRight.position, Vector2.down, edgeCheckDistance, groundLayer);

        if (isEdgeLeft || isEdgeRight || transform.position.x > startPosition.x + range || transform.position.x < startPosition.x - range)
        {
            moveRight = !moveRight;
        }
        if (moveRight)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        } else {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
