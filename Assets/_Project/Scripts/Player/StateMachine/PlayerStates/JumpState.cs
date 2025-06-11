using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
  public class JumpState : BaseState
  {
    public JumpState(PlayerController player, Rigidbody rb, Animator animator) : base(player, rb, animator)
    {
    }

    public override void OnEnter()
    {
      base.OnEnter();

      if (player.LogPlayerStates)
        Debug.Log("enter jump state");

      player.HandleJump();
    }

    public override void FixedUpdate()
    {
      player.HandleMovement();
    }
  }
}