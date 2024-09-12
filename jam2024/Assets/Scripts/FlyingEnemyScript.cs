using UnityEngine;

public class FlyingEnemyScript : AKillable
{
    public float radius = 1.75f;       // Radius of the circle
    public float speed = 1f;        // Speed of the circular movement
    public Vector2 centerPosition;  // Center of the circle

    private float _angle;            // Current angle of the enemy on the circle

    void Start()
    {
        // Initialize the angle
        _angle = 0f;

        // Optionally set the center to the starting position of the enemy
        centerPosition = transform.position;

        ResetPosition = transform.position;
    }

    void Update()
    {
        if (!isTesting)
        {
            if (!GameMaster.GameRunning || !Loaded ) return;
        }
        // Update the angle over time
        _angle += speed * Time.deltaTime;

        // Calculate the new position using trigonometry
        float x = Mathf.Cos(_angle) * radius;
        float y = Mathf.Sin(_angle) * radius;

        // Set the new position, relative to the center of the circle
        transform.position = new Vector2(centerPosition.x + x, centerPosition.y + y);
    }
    
    public override Vector3 ResetPosition { get; set; }

    public override void Reset()
    {
        transform.position = ResetPosition;
        _angle = 0;
        KillMe();
        RespawnMe();
    }
}


