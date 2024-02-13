using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class playerControler : MonoBehaviour
{
    public float walkSpeed;
    Vector2 moveInput;
    public bool IsMoving { get; private set; }
    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
    }


}
