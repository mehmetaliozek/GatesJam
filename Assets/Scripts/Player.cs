using UnityEngine;

public class Player : MonoBehaviour, IActivator
{
    public Rigidbody2D rb;

    public Animator animator;

    public float Speed;
    public float JumpForce;

    [SerializeField]
    private GameObject pointer;

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
        JumpForceCalculateWithScale();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocityY);

        Turn(moveInput);
        animator.SetFloat("Velocity", Mathf.Abs(moveInput));
    }

    private void Jump()
    {
        bool isGround = Physics2D.OverlapBox(ground.transform.position, new Vector2(transform.localScale.x, 0.1f), groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            SoundManager.PlaySound(SoundType.Jump);
            rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpForce * Mathf.Sign(transform.localScale.y));
        }

        if (!isGround)
        {
            if (rb.linearVelocityY > 0)
            {
                animator.SetInteger("JumpState", 1);
            }
            else
            {
                animator.SetInteger("JumpState", 2);
            }
        }
        else
        {
            animator.SetInteger("JumpState", 3);
        }
    }

    private void JumpForceCalculateWithScale()
    {
        if (transform.localScale.y > 2)
        {
            JumpForce = 4f;
        }
        else
        {
            JumpForce = 6f;
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
        pointer.SetActive(true);
    }

    public void Disable()
    {
        enabled = false;
        pointer.SetActive(false);
        rb.linearVelocity = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(ground.transform.position, new Vector2(transform.localScale.x, 0.1f));
    }
}
