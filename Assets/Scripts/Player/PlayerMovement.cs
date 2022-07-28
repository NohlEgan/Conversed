using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private float xVelocity;
    private bool isGrounded;
    private float lastGroundedTime;
    private float fallOffJumpWindow;
    private bool jump;

    private KeyCode jumpButton;

    [SerializeField]
    private LayerMask ground;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Transform playerBottom;

    [SerializeField]
    private float playerBottomRadius;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpDampening;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        xVelocity = 0;
        lastGroundedTime = 0;
        fallOffJumpWindow = 0.125f;
        jump = false;

        jumpButton = KeyCode.UpArrow;
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(playerBottom.position, playerBottomRadius, ground);

        if (isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Time.time - lastGroundedTime < fallOffJumpWindow && Input.GetKeyDown(jumpButton) && rb.velocity.y <= 0 && !GameManager.instance.IsGamePaused())
        {
            jump = true;
        }

        // slows down jump if jump button is released before jump reaches its peak
        if (Input.GetKeyUp(jumpButton))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpDampening);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (jump)
        {
            Jump();
            jump = false;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
    }

    private void Jump()
    {
        AudioManager.instance.PlayJumpSound();
        rb.velocity = Vector2.up * jumpForce;
        anim.SetBool("jump", true);
    }

    private void FinishAnimation()
    {
        anim.SetBool("jump", false);
    }
}
