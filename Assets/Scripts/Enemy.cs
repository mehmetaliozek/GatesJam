using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2f;
    public float raycastDistance = 0.1f;

    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        
        if (!IsGroundAhead())
        {
            Flip();
        }
    }

    bool IsGroundAhead()
    {
        Vector2 rayOrigin = (Vector2)transform.position + Vector2.right * direction * 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance);
        Debug.DrawRay(rayOrigin, Vector2.down * raycastDistance, Color.red);
        return hit.collider != null;
    }

    void Flip()
    {
        direction *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 rayOrigin = (Vector2)transform.position + Vector2.right * direction * 0.5f;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin, rayOrigin + Vector2.down * raycastDistance);
    }
}
