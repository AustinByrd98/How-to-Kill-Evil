using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class skeletonMove : MonoBehaviour
{
    public float walkSpeed = 3f;
    // component references
    TouchingDirections touchingDirections;
    Rigidbody2D rb;
    Animator animator;
    Damageable damageable;
    public detectionZone attack;
    // enum for local scale walkDirection

    public enum WalkableDirection { Right, Left}
    private WalkableDirection _walkDirection;
    public Vector2 WalkDirectionVector = new Vector2(1,0);

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set {
            if(_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkableDirection.Right)
                {
                    WalkDirectionVector = Vector2.right;
                }
                else
                {
                    WalkDirectionVector = Vector2.left;
                }
            }

            _walkDirection = value; }
    }
    public bool _hasTarget = false;
    public bool HasTarget { get { return _hasTarget; } private set {
            _hasTarget = value;
            animator.SetBool("attack", value);

        } }

    // Start is called before the first frame update
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();

    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = attack.detections.Count > 0;
    }

    public void FixedUpdate()
    {
        if(touchingDirections.isGround && touchingDirections.isOnWall && damageable.IsAlive)
        {
            FlipDirection();
        }

        if (damageable.IsAlive && !damageable.LockVel)
        {
            rb.velocity = new Vector2(walkSpeed * WalkDirectionVector.x, rb.velocity.y);
        }

        if(transform.position.x < 0 || transform.position.x > 0)
        {
            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FlipDirection()
    {
        if(WalkDirection== WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        } else if(WalkDirection== WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.LogError("WalkDirection was given an invald value");
        }
    }

  

  
}
