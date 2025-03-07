using UnityEngine;

// TODO: Karakter hareket kodlarý yazýlcak
public class Player : MonoBehaviour, IActivator
{
    public Rigidbody2D rb;

    public float Speed;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(x * Speed, rb.linearVelocityY);
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
