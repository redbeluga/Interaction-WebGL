using DG.Tweening;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
  [Header("Settings")]
  [SerializeField] private Vector3 offset;
  [SerializeField] private float animationDuration = 2f;
  private Vector3 _openPos;
  private Vector3 _closedPos;
  private bool _isOpen = false;

  void Start()
  {
    _closedPos = transform.localPosition;
    _openPos = _closedPos + offset;
  }

  public void OnInteract()
  {
    _isOpen = !_isOpen;
    if (_isOpen)
    {
      Open();
    }
    else
    {
      Close();
    }
  }

  private void Open()
  {
    transform.DOLocalMove(_openPos, animationDuration, false);
  }

  private void Close()
  {
    transform.DOLocalMove(_closedPos, animationDuration, false);
  }
}
