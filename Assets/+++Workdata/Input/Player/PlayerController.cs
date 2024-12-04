using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// if riders gives no recommendations, something is wrong
public class PlayerController : MonoBehaviour
{
    public GameInput inputActions;
    
    
    [Header("Movement")]
    [SerializeField]private float movementSpeed = 4f;
    [SerializeField]private float jumpPower = 4f;

    [Header("GroundCheck")] 
    [SerializeField] private Vector2 boxSize;
    
    
    private InputAction moveAction;
    private InputAction JumpAction;

    private bool isJumping;
    private bool canJump;
    
    private SpriteRenderer sr;
   
    public Vector2 moveInput; // vector2 is the variable for x,y 
    public Rigidbody2D rb; // to let the object move and change things
    public bool isFacingRight = true;

    private Animator animator;
    
    

    public void Flip() // to activate flip - character looks to left or right, depending with direction it walks
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale; 
        
        localScale.x *= -1;
        
        transform.localScale = localScale;
    }
    

    private void Awake() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); // name of the component in the ()
        
        inputActions = new GameInput();
        moveAction = inputActions.Player.Move; // to know that the player has to  move

        animator = GetComponent<Animator>();
        
    }
    
    private void OnEnable()
    {
        inputActions.Enable(); 

        moveAction.performed += Move; //subscribed
        moveAction.canceled += Move;
        
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * movementSpeed, rb.velocity.y);

        if (moveInput.x > 0 )
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
    private void OnDisable()
    {
        inputActions.Disable(); //disabled unsere InputMap, MUSS HIER SEIN)

        moveAction.performed -= Move; //unsubscribed
        moveAction.canceled -= Move;
        
    }
    
    private void Move(InputAction.CallbackContext ctx) // can be ctx or whatever you want
    {
        moveInput = ctx.ReadValue<Vector2>(); 
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (isGrounded && canJump) ;
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    
    private void Update()
    {
        animator.SetFloat("MovementValue" , Mathf.Abs(rb.velocity.x)); // abs so the animation goes in every directrion- it makes the number go from negative to positive
    }
    
}
