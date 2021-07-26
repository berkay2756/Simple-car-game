using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTurn : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform car;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Quaternion is responsible for rotation in unity.

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        car.Rotate(Vector3.up * mouseX); // rotate around y
    }
}
