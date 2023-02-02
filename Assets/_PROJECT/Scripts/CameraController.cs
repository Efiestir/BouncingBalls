using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [HideInInspector] public float turnX, currentX;
    private void Update()
    {
        turnX += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0, turnX, 0);
        currentX = transform.position.x;
    }

    public void LerpCameraWhileFalling()
    {
        transform.position = new Vector3(currentX, 2, -5);
        transform.localRotation = Quaternion.Euler(45,turnX , 0);
    }

    public void LerpCameraWhileAscending()
    {
        transform.position = new Vector3(currentX, 2, -5);
        transform.localRotation = Quaternion.Euler(45,turnX , 0);
    }
}
