using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public float moveInput;
    public int extraJumps;
    private int extraJumpsMax;

    [Header("Health")]
    public int health = 8;
    private int maxHealth;

    private Rigidbody2D rb;

    [Header("Debug")]
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Animator animator;


    private void Start()
    {
        maxHealth = health;
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumpsMax = extraJumps;
        animator = GetComponent<Animator>();
        Healthbar.singleton.SetHealth(health);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isGrounded && moveInput != 0)
        { animator.SetBool("isRunning", true);}
        else if (isGrounded && moveInput == 0)
        { animator.SetBool("isRunning", false);}

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
            extraJumps = extraJumpsMax;
        }
        else
        { animator.SetBool("isGrounded", false); }

        if ((Input.GetButtonDown("Jump") && extraJumps > 0))
        {
            Jump();
            extraJumps--;
        }
        else if ((Input.GetButtonDown("Jump") && extraJumps == 0) && isGrounded)
        { Jump(); }

        if (Input.GetKeyDown(KeyCode.V))
        { animator.SetTrigger("Taunt"); }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rb.velocity = Vector2.up * jumpForce;
    }

    public void TakeDamage()
    {
        health--;
        Healthbar.singleton.SetHealth(health);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
