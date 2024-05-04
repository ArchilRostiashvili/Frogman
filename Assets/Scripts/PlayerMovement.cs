using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Player's 2d collider
    private BoxCollider2D playerColl;

    private Rigidbody2D rb;
    //animator variable
    private Animator anim;

    private SpriteRenderer spriteRenderer;

    //setting the value from unity
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 14f;

    //Ground layer variable
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementSet { idle, running, jumping, falling}

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");

        //it gives itselve's BoxCollider2D
        playerColl = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //variable showing direction of player
        float dirX = Input.GetAxisRaw("Horizontal");

        //setting speed of player multiplyed by direction
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

        //checking if player is jumping
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, 0);
        }

        checkDirX(dirX);
    }
    private void checkDirX(float dirX)
    {
        MovementSet mvState;

        if(dirX > 0f)
        {
            mvState = MovementSet.running;
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f) { 
            mvState=MovementSet.running;
            spriteRenderer.flipX = true;

        }
        else 
        {
            mvState = MovementSet.idle;
        }

        if (rb.velocity.y > .1f)
        {
            mvState = MovementSet.jumping;
        } 
        else if(rb.velocity.y < -.1f){
            mvState = MovementSet.falling;
        }

        anim.SetInteger("mvState", (int)mvState);
    }

    //Checking Player's collision with ground
    private bool isGrounded()
    {
        //last four parameters are angle(rotation), direction, distance and collider of the Ground layer
        //we create the collider of the same shape as palyer's bounds
        return Physics2D.BoxCast(playerColl.bounds.center, playerColl.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
