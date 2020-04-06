using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerBaseState
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
        
    }
}
