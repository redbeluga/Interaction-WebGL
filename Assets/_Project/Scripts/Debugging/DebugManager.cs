using UnityEngine;

public class DebugManager : MonoBehaviour
{
  [Header("References")]
  [SerializeField] private GameObject graphy;

  [Header("Settings")]
  [SerializeField] private KeyCode toggleGraphy;

  void Update()
  {
    if (Input.GetKeyDown(toggleGraphy))
    {
      graphy.SetActive(!graphy.activeSelf);
    }
  }
}
