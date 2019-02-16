using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suriyun {
    public class ScrCamera : MonoBehaviour
    {
        static int characterAmount = 3;
        public GameObject[] characters = new GameObject[characterAmount];
        private int currentCharacter = 0;

        // https://answers.unity.com/questions/600577/camera-rotation-around-player-while-following.html
        public float turnSpeed = 4.0f;
        public Transform playerTransform;
        private Vector3 offset;

        void Start()
        {
            offset = new Vector3(playerTransform.position.x, playerTransform.position.y + 0.2f, playerTransform.position.z + 2.5f);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)) {
                if (currentCharacter < characterAmount - 1) {
                    currentCharacter++;
                }
                else {
                    currentCharacter = 0;
                }
            }

            for (int i = 0; i < characterAmount; i++) {
                characters[i].GetComponent<ScrMovement>().selected = false;
            }
            characters[currentCharacter].GetComponent<ScrMovement>().selected = true;
            playerTransform = characters[currentCharacter].transform;

            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            transform.position = playerTransform.position + offset;
            transform.LookAt(playerTransform.position);
        }
    }
}