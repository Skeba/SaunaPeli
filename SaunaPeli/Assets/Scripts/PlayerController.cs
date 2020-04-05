using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Main
{
    
    // Checks if player is touching the ground
    private bool isGrounded;
    // Invisible dot under character that checks for ground.
    public Transform feetPos;
    // Size of invisible sensor. 0.3 is good small number
    public float checkRadius;
    public float jumpForce;
    // Add this layer to everything which is ground that you can jump off.
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
    }

    // Update is called once per frame
    void Update() 
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer() 
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

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

    void Jump() 
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
