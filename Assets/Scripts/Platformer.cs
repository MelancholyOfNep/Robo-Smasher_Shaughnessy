using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Platformer : MonoBehaviour
{
    // Designate rigidbody reference
    public Rigidbody2D rb;

    // Designate speed
    public float speed;

    // Designate jumping force
    public float jumpingForce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Space))
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
}
