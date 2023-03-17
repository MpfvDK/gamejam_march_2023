using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float ladderSpeed;
    public float jumpHeight;
    float xInput;
    float yInput;
    public bool jumping = false;
    public bool onGround = true;
    public bool onLadder = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(onLadder && onGround)
            xInput = Input.GetAxisRaw("Horizontal");
        else if(onGround)
            xInput = Input.GetAxisRaw("Horizontal");
        else if(!onGround && !onLadder)
            xInput = Input.GetAxisRaw("Horizontal");

        yInput = Input.GetAxisRaw("Vertical");
        if (!onLadder)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (!jumping)
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpHeight);
                jumping = true;
            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);



        if (onLadder)
        {
            rb.gravityScale = 0;
        }
        else if (!onLadder)
        {
            rb.gravityScale = 1;
        }

        if (onLadder)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, yInput * ladderSpeed);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            onGround = true;
            jumping = false;
        }
        if (collision.collider.tag == "ladder")
        {
            onLadder = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            onGround = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        {
            onLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        {
            onLadder = false;
        }
    }
}
