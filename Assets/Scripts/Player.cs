using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D Rigidbody2D;
    public float Speed;
    public float JumpSpeed;

    public bool Grounded;

    public Animator Animator;

    public SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Rigidbody2D.velocity += new Vector2(0f, JumpSpeed);
            }
        }

        Animator.SetBool("Grounded", Grounded);
        Animator.SetFloat("VelocityY", Rigidbody2D.velocity.y);
        Animator.SetFloat("VelocityX", Mathf.Abs(Rigidbody2D.velocity.x));

        if (Rigidbody2D.velocity.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (Rigidbody2D.velocity.x < 0)
        {
            SpriteRenderer.flipX = true;
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, Rigidbody2D.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);
        if (dot > 0.5f)
        {
            Grounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }
}
