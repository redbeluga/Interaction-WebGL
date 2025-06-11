using UnityEngine;

namespace Player
{
  public class FallState : BaseState
  {
    public FallState(PlayerController player, Rigidbody rb, Animator animator) : base(player, rb, animator) { }

    public override void OnEnter()
    {
      base.OnEnter();

      if (player.LogPlayerStates)
        Debug.Log("entered fall state");
    }
  }
}