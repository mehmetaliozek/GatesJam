using UnityEngine;

// TODO: Karakter hareket kodlarý yazýlcak
public class Player : MonoBehaviour, IActivator
{
    public Rigidbody2D rb;

    public float Speed;

    public float JumpForce;

    [SerializeField]
    private Transform ground;
    [SerializeField]
    private LayerMask groundLayer;

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(x * Speed, rb.linearVelocityY);
    }

    private void Jump()
    {
        bool isGround = Physics2D.OverlapPoint(ground.transform.position, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}
