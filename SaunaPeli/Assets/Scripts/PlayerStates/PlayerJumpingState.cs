using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {

    }

    public override void OnCollisionEnter2D(PlayerController player)
    {
        player.TransitionToState(player.IdleState);
    }

    public override void Update(PlayerController player)
    {
        
        if (Input.GetKey(KeyCode.Space)) //  && isJumping == true
        {
            
            if (player.jumpTimeCounter > 0)
            {
                
                player.Rigidbody.velocity = Vector2.up * player.jumpForce;
                player.jumpTimeCounter -= Time.deltaTime;
                if (player.jumpTimeCounter <= 0)
                {
                    
                    player.TransitionToState(player.DoubleJumpingState);
                }
                
                // player.Rigidbody.velocity.AddForce(new Vector2(0f, jumpForce / 10), ForceMode2D.Impulse); 
                // player.TransitionToState(player.JumpingState);
            }

            //else
            //{
            //    isJumping = false;
            //}

        }
    }
}
