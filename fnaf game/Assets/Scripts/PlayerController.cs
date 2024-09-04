using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private float speed = 9.0f;
    private float horizontal, vertical;
    private CharacterController controller;
    private float gravity = -100f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Playermove();
    }

    private void Playermove ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (!controller.isGrounded)
        {
            move.y += gravity * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);

    }
}
