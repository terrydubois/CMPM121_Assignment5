using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suriyun {
    public class ScrMovement : MonoBehaviour
    {
        public float moveSpeed;
        private float rot = 0;
        public float rotSpeed = 80;
        public float gravity = 8;

        Vector3 moveDir = Vector3.zero;

        CharacterController controller;
        Animator animator;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (controller.isGrounded) {
                if (Input.GetKey(KeyCode.W)) {
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= moveSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (Input.GetKeyUp(KeyCode.W)) {
                    moveDir = Vector3.zero;
                }
            }

            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}