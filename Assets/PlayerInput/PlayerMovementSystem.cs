using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSystem : MonoBehaviour
{

    CharacterController cc;
    PlayerControls playerControls;
    [SerializeField] Camera cam;
    [SerializeField] Transform camTransform;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        motion = new();

        playerControls.Player.Enable();
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        input = playerControls.Player.Movement.ReadValue<Vector2>();
        motion.x = input.x;
        motion.z = input.y;


        float x = transform.position.x;
        float z = transform.position.z;
        cc.Move(motion * movementSensitivity * deltaTime);
        x -= transform.position.x;
        z -= transform.position.z;

        cameraRotX -= x * camMovementSensitivityX;
        cameraRotZ += z * camMovementSensitivityZ;

        camTransform.localRotation = Quaternion.Euler(cameraRotZ, 0, cameraRotX);
    }

    private void OnDestroy()
    {
        playerControls.Player.Disable();
    }

    Vector2 input;
    Vector3 motion;

    public float movementSensitivity;
    public float camMovementSensitivityX;
    public float camMovementSensitivityZ;

    float cameraRotX;
    float cameraRotZ;
}
