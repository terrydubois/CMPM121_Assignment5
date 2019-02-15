using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCameraFollow : MonoBehaviour
{
    Vector3 playerPos;
    public float cameraDistance = 5;

    void Start()
    {

    }

    void Update()
    {
        playerPos = transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(playerPos.x, playerPos.y + cameraDistance, playerPos.z - cameraDistance);
    }
}
