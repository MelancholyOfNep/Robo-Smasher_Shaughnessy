using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float shotSpeed;
    public Rigidbody2D rb;

    // Platformer target;
    Vector2 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // target = GameObject.FindObjectOfType<Platformer>();
        moveDir = (PlayerDeath.Instance.transform.position - transform.position).normalized*10;
        rb.velocity = new Vector2(moveDir.x, moveDir.y).normalized*shotSpeed;
    }

    /*void FixedUpdate()
    {
        rb.velocity = transform.right * shotSpeed;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
