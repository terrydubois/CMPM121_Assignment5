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

        public bool selected = false;

        Vector3 moveDir = Vector3.zero;

        CharacterController controller;
        Animator animator;
        //Animation animation;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            //animation = GetComponent<Animation>();
        }

        void Update()
        {

            if (selected && controller.isGrounded) {
                // walk forward
                if (Input.GetKey(KeyCode.UpArrow)) {
                    animator.SetInteger("animation", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= moveSpeed;
                    
                    // run if player is holding X
                    if (Input.GetKey(KeyCode.X)) {
                        moveDir *= 2;
                        animator.SetInteger("animation", 2);
                    }

                    moveDir = transform.TransformDirection(moveDir);
                }
                
                // walk backwards
                if (Input.GetKey(KeyCode.DownArrow)) {
                    animator.SetInteger("animation", 1);
                    moveDir = new Vector3(0, 0, -1);
                    moveDir *= moveSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                }

                // rotate if pressing left/right
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
                    float runMultiply = 1;
                    if (Input.GetKey(KeyCode.X)) {
                        runMultiply = 1.5f;
                    }
                    else {
                        animator.SetInteger("animation", 1);
                    }
                    rot += Input.GetAxis("Horizontal") * rotSpeed * runMultiply * Time.deltaTime;
                    transform.eulerAngles = new Vector3(0, rot, 0);
                }
            }

            // return to standstill
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
            || !selected) {
                animator.SetInteger("animation", 0);
                moveDir = Vector3.zero;
            }

            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}