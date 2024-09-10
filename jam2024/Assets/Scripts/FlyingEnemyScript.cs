using UnityEngine;

public class FlyingEnemyScript : MonoBehaviour
{
    public float radius = 1.75f;       // Radius of the circle
    public float speed = 1f;        // Speed of the circular movement
    public Vector2 centerPosition;  // Center of the circle

    private float angle;            // Current angle of the enemy on the circle

    void Start()
    {
        // Initialize the angle
        angle = 0f;

        // Optionally set the center to the starting position of the enemy
        centerPosition = transform.position;
    }

    void Update()
    {
        // Update the angle over time
        angle += speed * Time.deltaTime;

        // Calculate the new position using trigonometry
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Set the new position, relative to the center of the circle
        transform.position = new Vector2(centerPosition.x + x, centerPosition.y + y);
    }
}
