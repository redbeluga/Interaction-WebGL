using KBCore.Refs;
using UnityEngine;

namespace Interact
{
  public abstract class Interactable : ValidatedMonoBehaviour
  {
    [Header("Interactable References")]
    [SerializeField, Self] protected Collider col;
    protected bool _isInteractable = true;
    public bool IsInteractable => _isInteractable;
  }
}