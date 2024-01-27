using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Jobs;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTouchingWall;
    [SerializeField] private bool isWallSliding;
    [SerializeField] private bool canJump;

    [Range(0f, 100f)][SerializeField] public float groundCheckRadius = 10.0f;
    [Range(0f, 100f)][SerializeField] public float wallCheckDistance = 10.0f;
    [Range(0f, 100f)][SerializeField] public float movementSpeed = 10.0f;
    [Range(0f, 100f)][SerializeField] public float wallSlidingSpeed = 10.0f;
    [Range(0f, 100f)][SerializeField] public float movementForceInAir = 10.0f;
    [Range(0f, 100f)][SerializeField] public float airDragMultiplier = 10.0f;
    [Range(0f, 100f)][SerializeField] public float jumpForce = 10.0f;
    [Range(0f, 100f)][SerializeField] public float wallHopForce = 10.0f;
    [Range(0f, 100f)][SerializeField] public float wallJumpForce = 10.0f;
    [Range(0, 2)][SerializeField] public int amountOfJumps = 1;


    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask WhatIsGround;


    private Rigidbody2D rb;
    private int amountOfJumpsLeft = 1;
    private int facingDirection = 1;
    private float movementInputDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        amountOfJumpsLeft = amountOfJumps;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        CheckIfCanJump();
        CheckIfWallSliding();
    }

    private void FixedUpdate()
    {

        ApplyMovement();
        CheckSurroundings();
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, WhatIsGround);
    }

    private void CheckIfCanJump()
    {
        if ((isGrounded && rb.velocity.y <= 0) || isWallSliding)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void CheckIfWallSliding()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
    }
    private void ApplyMovement()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        }
        else if (!isGrounded && !isWallSliding && movementInputDirection != 0)
        {
            Vector2 forceToAdd = new Vector2(movementForceInAir * movementInputDirection, 0);
            rb.AddForce(forceToAdd);

            if (Mathf.Abs(rb.velocity.x) > movementSpeed)
            {
                rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
            }
        }

        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlidingSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
            }
        }
    }

    private void Flip()
    {
        if (!isWallSliding)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void Jump()
    {
        if (canJump && !isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }
        else if (isWallSliding && movementInputDirection == 0 && canJump) //Wall hop
        {
            isWallSliding = false;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * -facingDirection, wallHopForce * wallHopDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        else if ((isWallSliding || isTouchingWall) && movementInputDirection != 0 && canJump)
        {
            isWallSliding = false;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.y));

    }

}