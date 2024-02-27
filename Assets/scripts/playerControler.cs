using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class playerControler : MonoBehaviour
{
    public float walkSpeed;

    Vector2 jumpInput;

    public bool IsJumping
    {
        get
        {
            return is_jumping;
        }
        private set
        {
            is_jumping = value;
            animator.SetBool("isJumping", value);
        }
    }

    Vector2 moveInput;
    private bool is_moving;
    private bool is_jumping;
    public bool IsMoving
    {
        get
        {
            return is_moving;
        }
        private set
        {
            is_moving = value;

            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }
    public bool is_facing_right = true;
    public bool IsFacingRight { get
        {
            return is_facing_right;
        }
        private set
        {
            if (is_facing_right != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            is_facing_right = value;
        }
    }

    
    

    Rigidbody2D rb;
    public Animator animator;
    TouchingDirections touchingDirections;
    Damageable damageable;
    public float jumpAmount = 5f;

    // Start is called before the first frame update
    private void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
        animator = GetComponent < Animator >();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!damageable.LockVel)
        {
            rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);

        }
       
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
        
    }

    
    public void OnMove(InputAction.CallbackContext context)
    {
        if(animator.GetBool("canMove") && damageable.IsAlive )
        {
            moveInput = context.ReadValue<Vector2>();
            IsMoving = moveInput != Vector2.zero;

        }
        
           

            SetFacingDirection(moveInput);
        
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //jumpInput = context.ReadValue<Vector2>();
        if (context.started && animator.GetBool("canMove") && touchingDirections.isGround || touchingDirections.isOnWall && damageable.IsAlive)
        {
            animator.SetTrigger(AnimationStrings.playerJump);
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);

        }
        // new if statement for if (on wall) allow wall jump where it pushes player off wall
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attack);

        }
       
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);

    }

    


}
