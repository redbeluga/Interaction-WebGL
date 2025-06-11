using System.Collections.Generic;
using KBCore.Refs;
using UnityEngine;
using Utilities;


namespace Player
{
  public class PlayerController : ValidatedMonoBehaviour
  {
    [Header("Debugging")]
    [SerializeField] private bool logPlayerStates;
    [Header("References")]
    [SerializeField, Self] private GroundChecker groundChecker;
    [SerializeField, Self] private Rigidbody rb;
    [SerializeField, Self] private Animator animator;
    [SerializeField, Anywhere] private Transform playerModel;
    [SerializeField, Anywhere] private InputReader input;

    [Header("Locomotion Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float runSpeedMultiplier = 1.5f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpSpeed = 6f;

    public bool LogPlayerStates => logPlayerStates;

    private float _speedMultiplier = 1f;

    private List<Timer> _timers;

    private StateMachine _stateMachine;
    private bool _shouldCrouch;

    private void Awake()
    {
      rb.freezeRotation = true;
      SetupTimers();
      SetupStateMachine();
    }

    private void OnEnable()
    {
      SubscribeToInputEvents();
    }

    private void OnDisable()
    {
      UnsubscribeToInputEvents();
    }

    private void SetupStateMachine()
    {
      _stateMachine = new StateMachine();

      var locomotionState = new LocomotionState(this, rb, animator);
      var jumpState = new JumpState(this, rb, animator);
      var fallState = new FallState(this, rb, animator);
      var crouchState = new CrouchState(this, rb, animator);

      At(locomotionState, jumpState, new FuncPredicate(() => input.Jump));
      At(locomotionState, crouchState, new FuncPredicate(() => _shouldCrouch));

      At(crouchState, jumpState, new FuncPredicate(() => input.Jump));
      At(crouchState, locomotionState, new FuncPredicate(() => !_shouldCrouch));

      At(jumpState, fallState, new FuncPredicate(() => rb.linearVelocity.y < 0));
      At(fallState, locomotionState, new FuncPredicate(() => groundChecker.IsGrounded));

      _stateMachine.SetState(locomotionState);
    }

    void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

    private void SubscribeToInputEvents()
    {
      input.EnablePlayerActions();
      input.Run += OnRun;
      input.Crouch += OnCrouch;
    }

    private void UnsubscribeToInputEvents()
    {
      input.DisablePlayerActions();
      input.Run -= OnRun;
      input.Crouch -= OnCrouch;
    }

    private void Update()
    {
      HandleTimers();
      _stateMachine.Update();
    }

    private void FixedUpdate()
    {
      _stateMachine.FixedUpdate();
    }

    public void HandleMovement()
    {
      var movementDirection = playerModel.right * input.Direction.x + playerModel.forward * input.Direction.y;
      var horizontalVelocity = movementDirection * moveSpeed * _speedMultiplier;
      rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
    }

    public void HandleJump()
    {
      rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
    }

    private void SetupTimers()
    {
      _timers = new List<Timer>();
    }

    private void HandleTimers()
    {
      foreach (var timer in _timers)
      {
        timer.Tick(Time.deltaTime);
      }
    }

    private void OnRun(bool performed)
    {
      _speedMultiplier = performed ? runSpeedMultiplier : 1f;
    }

    private void OnCrouch(bool performed)
    {
      _shouldCrouch = performed;
    }
  }
}