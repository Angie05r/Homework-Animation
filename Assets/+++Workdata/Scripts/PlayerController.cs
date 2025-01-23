using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// if riders gives no recommendations, something is wrong
public class PlayerController : MonoBehaviour

{
   public GameInput inputActions;
  
   #region Private Variables
  
   [Header("Movement")]
   [SerializeField]private float movementSpeed = 4f;
   //[SerializeField] private float runSpeed = 7f;
   [SerializeField]private float jumpPower = 4f;

   private InputAction dashAction;

   public float dashSpeed = 17f;
   public float dashDuration = 0.5f;
   private bool isDashing = false;
   private Vector2 dashDirection;
   
   [Header("GroundCheck")]
   [SerializeField] private Vector2 boxSize;
   [SerializeField] private LayerMask groundLayer;
  
   private InputAction moveAction;
   private InputAction runAction;
   private InputAction JumpAction;
   private InputAction interactAction;

   
   private bool isJumping;
   private bool canJump;
   //private bool isRunning;
  
   private SpriteRenderer sr;
 
   private Vector2 moveInput; // vector2 is the variable for x,y
   private Rigidbody2D rb; // to let the object move and change things
   private bool isFacingRight = true;
 
   private bool isGrounded;
   [SerializeField]private Vector2 boxxOffset;

   private Interactable selectedInteractble;


   private Animator animator;
  
   #endregion
  
   public static readonly int Hash_MovementValue = Animator.StringToHash("Movement");


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
       
       JumpAction = inputActions.Player.Jump;
       dashAction = inputActions.Player.Dash;

       interactAction = inputActions.Player.Interact;

       animator = GetComponent<Animator>();
      
   }
  
   private void OnEnable()
   {

       moveAction.performed += Move; //subscribed
       moveAction.canceled += Move;
       
       JumpAction.performed += Jump;
       
       dashAction.performed += Dash;

       interactAction.performed += Interact;
   }
  
   private void FixedUpdate() 
   {
       CheckGround();
       if (!isDashing)
       {
           rb.linearVelocity = new Vector2(moveInput.x * movementSpeed, rb.linearVelocity.y);
       }

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

       moveAction.performed -= Move; //unsubscribed
       moveAction.canceled -= Move;
       
       
       JumpAction.performed -= Jump;
       //runAction.performed
       //runAction,canceled    
       dashAction.performed -= Dash;
       
       interactAction.performed -= Interact;
   }

   public void EnableInput()
   {
       // man kann es auch mit in OnEnable packen
       inputActions.Enable();
   }

   public void DisableInput()
   {
       // man kann es auch mit in OnDisable packen
       inputActions.Disable(); //disabled unsere InputMap, MUSS HIER SEIN)
   }
   
   
   #region workingDash
   public void Dash(InputAction.CallbackContext ctx)
   {
       if (ctx.performed && !isDashing)
       {
           // Dash-Richtung basierend auf der Eingabe
           dashDirection = moveInput.normalized; 
           StartCoroutine(DashCoroutine());
           Debug.Log("Dash");
       }
   }
   
   private IEnumerator DashCoroutine()
   {
       isDashing = true;
       float startTime = Time.time;
       Debug.Log("Starting Dash");

       while (Time.time < startTime + dashDuration)
       {
           Debug.Log("Dashing");
           rb.linearVelocity = new Vector2(dashDirection.x * dashSpeed, rb.linearVelocity.y);
           yield return null;
       }

       // Dash beendet, Bewegung zurücksetzen
       rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
       isDashing = false;
       Debug.Log("DashEnded");
   }
   
   #endregion

   
   
   void CheckGround()
   {
       isGrounded = Physics2D.OverlapBox( boxxOffset , transform.position, 0f,  groundLayer);
       Debug.Log(isGrounded);
   }
   private void Move(InputAction.CallbackContext ctx) // can be ctx or whatever you want
   {
       moveInput = ctx.ReadValue<Vector2>();
   }

   

   void UpdateAnimator()
   {
       int Hash_GroundValue = 0;
       animator.SetBool(Hash_GroundValue, isGrounded);
   }

   public void OnDrawGizmosSelected()
   {
      Gizmos.DrawWireCube(boxxOffset , boxSize );
   }

   private void Jump(InputAction.CallbackContext ctx) // damit man springen kann
   {
       if(!isGrounded)
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
      
   }
   
  
   private void Update()
   {
       animator.SetFloat("MovementValue" , Mathf.Abs(rb.linearVelocity.x)); // abs so the animation goes in every directrion- it makes the number go from negative to positive
       animator.SetBool("isDashing", isDashing);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       TrySelectInteractable(other);
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       TryDeselectInteractable(other);
   }
   
   #region Interaction

   private void Interact(InputAction.CallbackContext ctx)
   {
       if (selectedInteractble != null)
       {
           selectedInteractble.Interact();
       }
   }

  
   private void TrySelectInteractable(Collider2D other)
   {
       Interactable interactable = other.GetComponent<Interactable>();

       if (interactable == null) ;

       if (selectedInteractble != null)
       {
           selectedInteractble.Deselect();
       }

       selectedInteractble = interactable;
       selectedInteractble.Select();
   }

 
   private void TryDeselectInteractable(Collider2D other)
   {
       Interactable interactable = other.GetComponent<Interactable>();

       if (interactable == null) return;

       if (interactable == selectedInteractble)
       {
           selectedInteractble.Deselect();
           selectedInteractble = null;
       }
   }
   
   
   #endregion
   
}







