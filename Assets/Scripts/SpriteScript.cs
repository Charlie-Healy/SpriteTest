using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;
    bool isJumping;
    int jumpForce = 10;

    //float speed
    float speed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        isGrounded = false;
        isJumping = false;
        speed = 5.0f;
    }
   void Update()
    {
        MoveSprite();
        DoJump();
        DoLand();
    }

    void DoJump()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 8, 0) * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            anim.SetBool("walk", false);
            isJumping =true;
        }
    }

    void DoLand()
    {
        if( isGrounded && isJumping && rb.velocity.y <= 0 )
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

    }


    void MoveSprite()
    {

        if (Input.GetKey("a") == true)
        {
            print("player pressed a");
            rb.velocity = new Vector2(-12f, rb.velocity.y);
            sr.flipX = true;
        }
        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            rb.velocity = new Vector2(12f, rb.velocity.y);
            sr.flipX = false;
        }

        anim.SetBool("walk", false);

        if (isJumping == false)
        {
            if (rb.velocity.x > 0.2f || rb.velocity.x < -0.2f)
            {
                anim.SetBool("walk", true);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        //print("isgrounded");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}


