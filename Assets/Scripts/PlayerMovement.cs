using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity, move;
    private float horizontalAxis, verticalAxis;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        move = transform.right * horizontalAxis + transform.forward * verticalAxis;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime / 2);
    }
}