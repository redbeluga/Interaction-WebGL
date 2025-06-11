using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
  public class LocomotionState : BaseState
  {
    public LocomotionState(PlayerController player, Rigidbody rb, Animator animator) : base(player, rb, animator) { }

    public override void OnEnter()
    {
      base.OnEnter();

      if (player.LogPlayerStates)
        Debug.Log("enter locomotion state");
    }

    public override void FixedUpdate()
    {
      base.FixedUpdate();
      player.HandleMovement();
    }
  }
}