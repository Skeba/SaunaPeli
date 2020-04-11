using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Main
{
    
    // Checks if player is touching the ground
    // public bool isGrounded;
    // Invisible dot under character that checks for ground.
    // public Transform feetPos;
    // Size of invisible sensor.
    // public float checkRadius;
    public float jumpForce;
    // Add this layer to everything which is ground that you can jump off.
    // public LayerMask whatIsGround;
    public float jumpTimeCounter;

    public Animator animator;

    public float jumpTime;
    

    public Rigidbody2D Rigidbody
    {
        get { return rb; }
    }

    private PlayerBaseState currentState;

    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerJumpingState JumpingState = new PlayerJumpingState();
    public readonly PlayerDoubleJumpState DoubleJumpingState = new PlayerDoubleJumpState();


    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        TransitionToState(IdleState);
    }

    // Update is called once per frame
    void Update() 
    {

        MovePlayer();
        currentState.Update(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this);
    }
    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        // Flips character depending on direction of movement.
        if (horizontalMovement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(horizontalMovement < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon) 
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed;
            horizontalMovement += transform.position.x;

            float right = gameSceneController.screenBounds.x - halfWidth;
            float left = -right;

            float limit = Mathf.Clamp(horizontalMovement, left, right);

            transform.position = new Vector2(limit, transform.position.y);
        }
    }
}
