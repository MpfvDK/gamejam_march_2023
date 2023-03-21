using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float ladderSpeed;
    public float jumpHeight;
    public GameObject player;
    float xInput;
    float yInput;
    public bool jumping = false;
    public bool doublejumpUsed = false;
    public bool dbPlaceholder = false;
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
                if (!doublejumpUsed)
                {
                    if (dbPlaceholder)
                    {
                        doublejumpUsed = true;
                        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpHeight);
                    }
                    else
                    {
                        float dbHeight = jumpHeight / 0.5f;
                        dbPlaceholder = true;
                        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 0.1f);
                        rb.velocity = new Vector2(rb.velocity.x * 1.5f, rb.velocity.y + dbHeight);
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {

        if (onLadder && !onGround)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }

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
            doublejumpUsed = false;
            dbPlaceholder = false;
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
            dbPlaceholder = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
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
