using JetBrains.Annotations;
using UnityEngine;

public class HeelsMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private float input;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] int maxJumps;
    int jumpsRemaining;



    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            input = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input = 1;
        }
        else input = 0;

        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.linearVelocityY = 0;
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            jumpsRemaining = jumpsRemaining - 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = input * speed;
    }
}
