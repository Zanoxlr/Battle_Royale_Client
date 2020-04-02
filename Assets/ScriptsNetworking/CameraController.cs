using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerManager player;
    public float sensitivity = 3f;
    public float clampAngle = 90f;
    float sens;
    private float yRotation;
    private float xRotation;
    bool toggleMouse = false;
    public GameObject MenuObject;
    private void Start()
    {
        yRotation = transform.rotation.x;
        xRotation = transform.rotation.y;
        // Disable cursor
        EscapePressed();
        sens = sensitivity;
    }
    private void Update()
    {
        Look();
    }
    private void Look()
    {
        // Mouse look
        yRotation += Input.GetAxis("Mouse X") * sensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // Disable cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed();
        }
    }
    void EscapePressed()
    {
        if (toggleMouse == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            toggleMouse = false;
            sensitivity = 0;
            MenuObject.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            toggleMouse = true;
            sensitivity = 3;
            MenuObject.SetActive(false);
        }
    }
}
