using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Include the new Input System namespace

public class CamBehavior : MonoBehaviour
{
    public float speedH = 0.3f;
    public float speedV = 0.2f;

    public float yawRange = 3.8f;
    public float pitchRange = 2.5f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Quaternion initAngles;
    private Vector3 newAngles;

    private void Update()
    {
        // Get mouse delta using the new Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        yaw += speedH * mouseDelta.x;
        pitch -= speedV * mouseDelta.y;

        yaw = Mathf.Clamp(yaw, -yawRange, yawRange);
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);

        newAngles = new Vector3(pitch, yaw, 0.0f);
        initAngles = transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newAngles), Time.deltaTime * 4f);
    }
}
