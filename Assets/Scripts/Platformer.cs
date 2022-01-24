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

    // Designate grounded check and associated items
    bool isGrounded = false;
    public float groundRayLength;
    public LayerMask layers;

    // Designate direction for Shoot script
    public bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
        isGrounded = Physics2D.Raycast(transform.position,
            -transform.up, groundRayLength, layers);
        Debug.DrawRay(transform.position, -transform.up * groundRayLength);
        directionCheck();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void directionCheck()
    {
        if (rb.velocity.x > 0)
            isFacingRight = true;
        else if (rb.velocity.x < 0)
            isFacingRight = false;
    }
}
