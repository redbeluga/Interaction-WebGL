using UnityEngine;

namespace Player
{
  public class CrouchState : BaseState
  {
    public CrouchState(PlayerController player, Rigidbody rb, Animator animator) : base(player, rb, animator) { }

    public override void OnEnter()
    {
      base.OnEnter();

      if (player.LogPlayerStates)
        Debug.Log("entered crouch state");


    }
  }
}