using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    [SerializeField] Canvas FutureGameCanvas;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input;
    public bool jumpInput;
    public bool timeInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;
            playerControls.PlayerActions.Jump.performed += i => jumpInput = true;
            playerControls.PlayerActions.Time.performed += i => timeInput = true;
            playerControls.PlayerActions.Time.canceled += i => timeInput = false;



        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpingInput();
        HandleTimeInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;


        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)+ Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (b_Input && moveAmount >0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleJumpingInput()
    {
        if (jumpInput)
        {
            jumpInput = false;
            playerLocomotion.HandleJumping();
        }
    }

    private void HandleTimeInput()
    {
        GameObject[] futureObjects = GameObject.FindGameObjectsWithTag("Future");
        GameObject[] presentObjects = GameObject.FindGameObjectsWithTag("Present");

            if (timeInput)
            {
                FutureGameCanvas.enabled = true;
            }
            else
            {
                FutureGameCanvas.enabled = false;
            }
            
         foreach(GameObject items in presentObjects)
            if (timeInput)
            {
                items.GetComponent<Renderer>().enabled = false;
                items.GetComponent<Collider>().enabled = false;              
            }
            else
            {
                items.GetComponent<Renderer>().enabled = true;
                items.GetComponent<Collider>().enabled = true;
            }

        foreach(GameObject items in futureObjects)
            if (timeInput)
            {
                items.GetComponent<Renderer>().enabled = true;
                items.GetComponent<Collider>().enabled = true;              
            }
            else
            {
                items.GetComponent<Renderer>().enabled = false;
                items.GetComponent<Collider>().enabled = false;
            }


    }
}
