using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] GameObject playerCamera;
    [SerializeField] float mouseSpeed;

    const float mouseSensitivity = 100;
    float xRotation;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Mouse X") * mouseSpeed * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSpeed * mouseSensitivity * Time.deltaTime;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * x);
    }
}
