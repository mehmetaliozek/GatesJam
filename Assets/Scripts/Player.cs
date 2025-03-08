using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IActivator
{
    public Rigidbody2D rb;

    public float Speed;
    public float JumpForce;

    [SerializeField]
    private Transform ground;
    [SerializeField]
    private LayerMask groundLayer;

    private void Start()
    {

    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocityY);

        Turn(moveInput);
    }

    private void Jump()
    {
        bool isGround = Physics2D.OverlapBox(ground.transform.position, new Vector2(transform.localScale.x,0.1f), groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpForce * Mathf.Sign(transform.localScale.y));
        }
    }

    private void Turn(float moveInput)
    {
        if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
        rb.linearVelocity = Vector2.zero;
    }
}
