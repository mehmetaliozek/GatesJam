using UnityEngine;

// TODO: Karakter hareket kodlar� yaz�lcak
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public float Speed;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(x * Speed, rb.linearVelocityY);
    }
}
