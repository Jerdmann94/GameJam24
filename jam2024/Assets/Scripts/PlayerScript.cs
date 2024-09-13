using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Camera;

public class PlayerScript : MonoBehaviour
{
    private Camera _camera;
    public Sprite groundSprite;
    public Sprite jumpSprite; 
    public Sprite fallSprite; 

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    public float runMovement = 3f;

    public float jumpForce = 5f;
    public float groundCheckRadius = 0.2f; // The radius of the ground check
    public LayerMask groundLayer;          // The layer for ground objects
    public Transform groundCheck;   
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _camera = main;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = groundSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera) _camera.transform.position = transform.position + new Vector3(0, 0, -10);

        if (rb.velocity.y > 0)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else if (rb.velocity.y < 0)
        {
            spriteRenderer.sprite = fallSprite;
        }
        else if (rb.velocity.y == 0)
        {
            spriteRenderer.sprite = groundSprite;
        }

        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-runMovement, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(runMovement, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
