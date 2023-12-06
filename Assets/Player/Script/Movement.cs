using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ParticleSystem DustRun;

    public float speed = 5f;
    public float sprintSpeed = 10f; // Assign a value to sprintSpeed

    private bool isSprinting = false;

    void Update()
    {
        // Get input for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized * Time.deltaTime;

        // Check if sprinting and adjust speed accordingly
        if (isSprinting)
        {
            CreateDustRun();
            transform.Translate(moveDirection * sprintSpeed);
        }
        else
        {
            transform.Translate(moveDirection * speed);
        }
    }

    void CreateDustRun()
    {
        DustRun.Play();
    }
}
