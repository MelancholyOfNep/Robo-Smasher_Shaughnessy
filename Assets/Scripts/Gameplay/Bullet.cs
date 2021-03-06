using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotSpeed = 15f;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        rb.velocity = transform.right * shotSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
