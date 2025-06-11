using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class BaseState : IState
    {
        protected readonly PlayerController player;
        protected readonly Rigidbody rb;
        protected readonly Animator animator;

        protected BaseState(PlayerController player, Rigidbody rb, Animator animator)
        {
            this.player = player;
            this.animator = animator;
            this.rb = rb;
        }

        public virtual void OnEnter()
        {
            // noop
        }

        public virtual void Update()
        {
            // noop
        }

        public virtual void FixedUpdate()
        {
            // noop
        }

        public virtual void HandleCollision(Collision2D collision)
        {
            // noop
        }

        public virtual void OnExit()
        {
            // noop
        }
    }
}