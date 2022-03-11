using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float worldGravity = -9.81f;
    [SerializeField] Transform basePoint;
    [SerializeField] LayerMask floorLayerMask;

    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 newPosition = (transform.right * x + transform.forward * y) * movementSpeed * Time.deltaTime;

        controller.Move(newPosition);
    }

    void Jump()
    {
        isGrounded = Physics.CheckBox(basePoint.position, new Vector3(0.8f, 1f, 0.8f), Quaternion.identity, floorLayerMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpForce * -2 * worldGravity);

        velocity.y += worldGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
