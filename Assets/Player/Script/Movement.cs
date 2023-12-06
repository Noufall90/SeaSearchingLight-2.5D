using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ParticleSystem DustRun;
    
    public float speed = 5f;
    public float sprintSpeed;
    private bool isSprinting = false;

    void Update() 
    {
        float moveSpeed = speed;
        Vector3 moveDirection = Vector3.zero; // Initializing moveDirection
        
        if (Input.GetKey(KeyCode.LeftShift)) {
            CreateDustRun();
            moveSpeed = sprintSpeed;
            isSprinting = true;
        }
        else {
            isSprinting = false;
        }
        
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Calculate the movement direction
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized * moveSpeed * Time.deltaTime;
        
        // Move the GameObject
        transform.Translate(moveDirection);
    }
    
    void CreateDustRun()
    {
        DustRun.Play();
    }
}
