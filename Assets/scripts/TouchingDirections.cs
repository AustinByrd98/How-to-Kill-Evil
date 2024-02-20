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
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    private float groundDistance= 0.05f;
    private float wallDistance= 0.2f;
    private float ceilingDistance= 0.05f;

    private bool _isgrounded;
    private bool _isOnWall;
    private bool _isOnCeiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool isGround { get { return _isgrounded; } private set { _isgrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);} }

    public bool isOnWall
    {
        get { return _isOnWall; }
        private set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    public bool isOnCeiling
    {
        get { return _isOnCeiling; }
        private set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }
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
         isGround = touchingcol.Cast(Vector2.down, castFilter, groundHits, groundDistance)> 0 ;
        isOnWall = touchingcol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance)> 0 ;
        isOnCeiling = touchingcol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance)> 0 ;
    }
}
