using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]

public class BasicPlayerController : MonoBehaviour
{
    public Camera PlayerCamera;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;
    public float Gravity = 10f;

    public float LookSpeed = 2f;
    public float LookXLimit = 45f;

    Vector3 MoveDirection = Vector3.zero;
    float RotationX = 0;

    public bool CanMove = true;

    CharacterController CharacterController;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Handles movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Running
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = CanMove ? (isRunning ? RunSpeed : WalkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = CanMove ? (isRunning ? RunSpeed : WalkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = MoveDirection.y;
        MoveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // handles rotation
        CharacterController.Move(MoveDirection * Time.deltaTime);

        if (CanMove)
        {
            RotationX += -Input.GetAxis("Mouse Y") * LookSpeed;
            RotationX = Mathf.Clamp(RotationX, -LookXLimit, LookXLimit);
            PlayerCamera.transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * LookSpeed, 0);
        }
    }
}
