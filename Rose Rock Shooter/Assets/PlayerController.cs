using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public float moveInput;
    public int extraJumps;
    private int extraJumpsMax;


    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumpsMax = extraJumps;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isGrounded && moveInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else if (isGrounded && moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }

        if (!facingRight && moveInput > 0)
        { Flip(); }
        else if (facingRight && moveInput < 0)
        { Flip(); }
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
            extraJumps = extraJumpsMax;
        }

        if ((Input.GetButtonDown("Jump") && extraJumps > 0))
        {
            Jump();
            extraJumps--;
        }
        else if ((Input.GetButtonDown("Jump") && extraJumps == 0) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        animator.SetBool("isGrounded", false);
        animator.SetBool("isJumping", true);
        rb.velocity = Vector2.up * jumpForce;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
