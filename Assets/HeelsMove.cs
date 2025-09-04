using UnityEngine;

public class HeelsMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private float input;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = input * speed;
    }
}
