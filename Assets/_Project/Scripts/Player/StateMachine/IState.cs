using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IState
    {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void HandleCollision(Collision2D collision);
        void OnExit();
    }
}