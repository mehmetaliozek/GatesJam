using UnityEngine;

// TODO: Karakter hareket kodlarý yazýlcak
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float Speed;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(x * Speed * Time.deltaTime, rb.linearVelocityY);
    }
}
