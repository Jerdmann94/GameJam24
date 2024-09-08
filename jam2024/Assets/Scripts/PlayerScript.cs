using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Camera;

public class PlayerScript : MonoBehaviour
{
    private Camera _camera;

    private Transform player;

    private Rigidbody2D rb;

    private bool isGrounded;

    public float runMovement = 2f;

    public float jumpForce = 4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera) _camera.transform.position = transform.position + new Vector3(0, 0, -10);

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
}
