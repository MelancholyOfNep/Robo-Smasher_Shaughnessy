using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float shotSpeed = 10f;
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
