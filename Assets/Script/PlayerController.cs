using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6f;
    public float jumpForce = 18f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // GERAK (tidak ganggu gravitasi)
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

        // CEK TANAH (RAYCAST)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        bool isGrounded = hit.collider != null;

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

        // LOMPAT
        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            Debug.Log("LOMPAT BERHASIL");
        }

        jumpPressed = false;
    }

    // DIPANGGIL OTOMATIS
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpPressed = true;
        }
    }
}