using System;
using KBCore.Refs;
using Player;
using UnityEngine;

public class CameraManager : ValidatedMonoBehaviour
{
  [Header("References")]
  [SerializeField, Child] private Camera cam;
  [SerializeField, Child] private AudioListener audioListener;
  [SerializeField, Anywhere] private InputReader inputReader;
  [SerializeField, Anywhere] private Transform playerOrientation;

  [Header("Settings")]
  [SerializeField, Range(0f, 25f)] private float sensitivity = 12f;

  private float xRot, yRot;

  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    xRot = transform.eulerAngles.x;
    yRot = transform.eulerAngles.y;
  }

  private void OnEnable()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    inputReader.Look += OnLook;
  }

  private void OnDisable()
  {
    inputReader.Look -= OnLook;
  }

  private void OnLook(Vector2 cameraMovement, bool isDeviceMouse)
  {
    var mouseX = cameraMovement.x * Time.deltaTime * sensitivity;
    var mouseY = cameraMovement.y * Time.deltaTime * sensitivity;

    yRot += mouseX;

    xRot -= mouseY;
    xRot = Mathf.Clamp(xRot, -90f, 90f);

    transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    playerOrientation.rotation = Quaternion.Euler(0, yRot, 0);
  }
}