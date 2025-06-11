using UnityEngine;
using UnityEngine.Events;

namespace Interact
{
  public class InteractableItem : Interactable
  {
    [Header("Events")]
    [SerializeField] private UnityEvent Interact;

    public void RequestInteract()
    {
      Interact?.Invoke();
    }
  }
}