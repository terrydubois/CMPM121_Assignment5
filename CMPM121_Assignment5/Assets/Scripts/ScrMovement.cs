using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suriyun {
    public class ScrMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float jumpSpeed;
        private float rot = 0;
        public float rotSpeed = 80;
        public float gravity = 8;

        Vector3 moveDir = Vector3.zero;

        CharacterController controller;
        Animator animator;
        private Rigidbody rb;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
        
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                animator.SetInteger("animation", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= moveSpeed;
                
                if (Input.GetKey(KeyCode.Space)) {
                    moveDir *= 2;
                    animator.SetInteger("animation", 2);
                }

                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) {
                animator.SetInteger("animation", 0);
                moveDir = Vector3.zero;
            }
            
            if (controller.isGrounded) {
                if (Input.GetKey(KeyCode.Z)) {
                    var jumpForce = new Vector3(0, 1, 0);
                    jumpForce *= jumpSpeed;
                    jumpForce = transform.TransformDirection(jumpForce);
                    controller.Move(jumpForce * Time.deltaTime);
                }
            }
            

            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}