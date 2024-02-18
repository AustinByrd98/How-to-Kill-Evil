using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator animator;
    CapsuleCollider2D touchingcol;
    public ContactFilter2D castFilter;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    private float groundDistance= 0.05f;
    private bool _isgrounded;
    public bool isGround { get { return _isgrounded; } private set { _isgrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);

        } }

    // Start is called before the first frame

    private void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
         touchingcol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
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
         isGround= touchingcol.Cast(Vector2.down, castFilter, groundHits, groundDistance)> 0 ;
    }
}
