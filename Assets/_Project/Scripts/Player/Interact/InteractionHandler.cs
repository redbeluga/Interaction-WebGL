using KBCore.Refs;
using Player;
using UnityEngine;

namespace Interact
{
  public class InteractionHandler : ValidatedMonoBehaviour
  {
    [Header("References")]
    [SerializeField, Anywhere] private Camera playerCamera;
    [SerializeField, Anywhere] private InputReader inputReader;

    [Header("Settings")]
    [SerializeField] private float raycastDistance;


    public Interactable FocusedItem { get; private set; }

    private void Start()
    {

      inputReader.Interact += OnInteract;
    }

    private void Update()
    {
      HandleRaycast();
    }

    public void HandleRaycast()
    {
      var rayOrigin = playerCamera.transform.position;
      var rayDirection = playerCamera.transform.forward;

      FocusedItem = null;

      RaycastHit[] hits = Physics.RaycastAll(rayOrigin, rayDirection, raycastDistance);

      foreach (var hit in hits)
      {
        if (hit.collider.TryGetComponent<Interactable>(out var item) && item.IsInteractable)
        {
          FocusedItem = item;
          break;
        }
      }
    }

    private void OnInteract()
    {
      if (FocusedItem is InteractableItem interactableItem)
      {
        interactableItem.RequestInteract();
      }
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * raycastDistance);
    }
  }
}