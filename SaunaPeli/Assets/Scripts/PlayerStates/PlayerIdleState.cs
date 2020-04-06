using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    
    
    public override void EnterState(PlayerController player)
    {

    }

    public override void OnCollisionEnter2D(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        // player.isGrounded = Physics2D.OverlapCircle(player.feetPos.position, player.checkRadius, player.whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space)) //  && player.isGrounded == true
        {
            player.jumpTimeCounter = player.jumpTime;
            player.Rigidbody.velocity = Vector2.up * player.jumpForce; // Mass:1 GravityScale:5 Jumpforce:10 JumpTime:0.35
            // player.Rigidbody.velocity.AddForce(new Vector2(0f, player.jumpForce), ForceMode2D.Impulse); //Mass:1 GravityScale:4 Jumpforce:4 JumpTime:0.15
            player.TransitionToState(player.JumpingState);
        }

        

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    isJumping = false;
        //}
    }
}
