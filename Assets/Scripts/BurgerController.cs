using UnityEngine;

public class BurgerController : MonoBehaviour
{
    public float jumpForce = 8f;
    public float holdJumpForce = 18f;
    public float maxHoldTime = 0.25f;

    private Rigidbody2D rb;

    private bool isGrounded = false;
    private bool isGameOver = false;
    private bool isHoldingJump = false;

    private float holdTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryStartJump();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            HoldJump();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            StopHoldingJump();
        }
    }

    private void TryStartJump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        isGrounded = false;
        isHoldingJump = true;
        holdTimer = 0f;
    }

    private void HoldJump()
    {
        if (!isHoldingJump)
        {
            return;
        }

        if (holdTimer >= maxHoldTime)
        {
            StopHoldingJump();
            return;
        }

        rb.velocity = new Vector2(
            rb.velocity.x,
            rb.velocity.y + holdJumpForce * Time.deltaTime
        );

        holdTimer += Time.deltaTime;
    }

    private void StopHoldingJump()
    {
        isHoldingJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
            isHoldingJump = false;
            holdTimer = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }

    public void StopBurger()
    {
        isGameOver = true;
        isHoldingJump = false;
        rb.velocity = Vector2.zero;
    }
}
