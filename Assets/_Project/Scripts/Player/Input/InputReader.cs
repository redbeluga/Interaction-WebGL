using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
  /// <summary>
  /// Handles player input using Unity's Input System and exposes events for input actions.
  /// This ScriptableObject implements the <see cref="PlayerInputActions.IPlayerActions"/> interface
  /// to respond to input events such as movement, looking, running, interacting, and jumping.
  /// </summary>
  [CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
  public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions
  {
    /// <summary>
    /// Event triggered when the player moves. Provides the movement direction as a <see cref="Vector2"/>.
    /// </summary>
    public event UnityAction<Vector2> Move = delegate { };

    /// <summary>
    /// Event triggered when the player looks around. Provides the look direction as a <see cref="Vector2"/>
    /// and a boolean indicating whether the input is from a mouse.
    /// </summary>
    public event UnityAction<Vector2, bool> Look = delegate { };

    /// <summary>
    /// Event triggered when mouse control for the camera is enabled.
    /// </summary>
    public event UnityAction EnableMouseControlCamera = delegate { };

    /// <summary>
    /// Event triggered when mouse control for the camera is disabled.
    /// </summary>
    public event UnityAction DisableMouseControlCamera = delegate { };

    /// <summary>
    /// Event triggered when the player starts or stops running. Provides a boolean indicating
    /// whether the player is running.
    /// </summary>
    public event UnityAction<bool> Run = delegate { };

    public event UnityAction<bool> Crouch = delegate { };

    public event UnityAction<int> Select = delegate { };

    public event UnityAction Interact = delegate { };
    public event UnityAction Drop = delegate { };

    /// <summary>
    /// Event triggered when the player interacts with an object.
    /// </summary>
    // public bool Interact => _inputActions.Player.Interact.triggered;

    // public bool Drop => _inputActions.Player.Drop.triggered;


    /// <summary>
    /// Event triggered when the player jumps.
    /// </summary>
    public bool Jump => _inputActions.Player.Jump.triggered;

    private PlayerInputActions _inputActions;

    /// <summary>
    /// Gets the current movement direction as a <see cref="Vector3"/>.
    /// </summary>
    public Vector3 Direction => _inputActions.Player.Move.ReadValue<Vector2>();

    private void OnEnable()
    {
      if (_inputActions == null)
      {
        _inputActions = new PlayerInputActions();
        _inputActions.Player.SetCallbacks(this);
      }
    }

    /// <summary>
    /// Enables the player input actions.
    /// </summary>
    public void EnablePlayerActions()
    {
      _inputActions.Enable();
    }

    /// <summary>
    /// Disables the player input actions.
    /// </summary>
    public void DisablePlayerActions()
    {
      _inputActions.Disable();
    }

    /// <summary>
    /// Called when the player moves. Invokes the <see cref="Move"/> event.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    public void OnMove(InputAction.CallbackContext context)
    {
      Move.Invoke(context.ReadValue<Vector2>());
    }

    /// <summary>
    /// Called when the player looks around. Invokes the <see cref="Look"/> event.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    public void OnLook(InputAction.CallbackContext context)
    {
      Look.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));
    }

    /// <summary>
    /// Checks if the input device is a mouse.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    /// <returns>True if the input device is a mouse; otherwise, false.</returns>
    private bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";

    /// <summary>
    /// Called when mouse control for the camera is toggled. Invokes the <see cref="EnableMouseControlCamera"/>
    /// or <see cref="DisableMouseControlCamera"/> event based on the input phase.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    public void OnMouseControlCamera(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          EnableMouseControlCamera.Invoke();
          break;
        case InputActionPhase.Canceled:
          DisableMouseControlCamera.Invoke();
          break;
      }
    }

    public void OnNumKeys(InputAction.CallbackContext context)
    {
      if (context.phase == InputActionPhase.Started)
      {
        var value = (int)context.ReadValue<float>();

        Select.Invoke(value);
      }
    }

    /// <summary>
    /// Called when the player starts or stops running. Invokes the <see cref="Run"/> event.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    public void OnRun(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          Run.Invoke(true);
          break;
        case InputActionPhase.Canceled:
          Run.Invoke(false);
          break;
      }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          Crouch.Invoke(true);
          break;
        case InputActionPhase.Canceled:
          Crouch.Invoke(false);
          break;
      }
    }

    /// <summary>
    /// Called when the player interacts. Invokes the <see cref="Interact"/> event.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    public void OnInteract(InputAction.CallbackContext context)
    {
      if (context.phase == InputActionPhase.Started)
      {
        Interact.Invoke();
      }
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
      if (context.phase == InputActionPhase.Started)
      {
        Drop.Invoke();
      }
    }

    /// <summary>
    /// Called when the player jumps. Invokes the <see cref="Jump"/> event.
    /// </summary>
    /// <param name="context">The input action callback context.</param>
    public void OnJump(InputAction.CallbackContext context)
    {

    }
  }
}