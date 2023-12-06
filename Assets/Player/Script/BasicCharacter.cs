using System;
using UnityEngine;

namespace Common.Scripts
{
    public class BasicCharacter : MonoBehaviour
    {
        private static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");

        [SerializeField] private float speed = 10f;
        [SerializeField] private float sprintSpeed = 15f;
        [SerializeField] private float raycastDistance = 1f; // Distance from the object to the ground
        [Header("Relations")]
        [SerializeField] private Animator animator = null;
        [SerializeField] private Rigidbody physicsBody = null;
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        private Vector3 _movement;
        private bool isSprinting = false;

        private void Update()
        {
            // Vertical
            float inputY = 0;
            if (Input.GetKey(KeyCode.W))
                inputY = 1;
            else if (Input.GetKey(KeyCode.S))
                inputY = -1;

            // Horizontal
            float inputX = 0;
            if (Input.GetKey(KeyCode.D))
            {
                inputX = 1;
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                inputX = -1;
                spriteRenderer.flipX = true;
            }

            // Normalize
            _movement = new Vector3(inputX, 0, inputY).normalized;

            // Sprint mechanic
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

            float currentSpeed = isSprinting ? sprintSpeed : speed;

            // Update animator based on movement
            animator.SetBool(WALK_PROPERTY, Math.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);

            // Move the player
            physicsBody.velocity = _movement * currentSpeed;

            // Maintain the object on the ground using Raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
            {
                float distanceToGround = hit.distance;
                transform.position = new Vector3(transform.position.x, transform.position.y - distanceToGround, transform.position.z);
            }
        }
    }
}
