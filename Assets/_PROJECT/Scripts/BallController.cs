using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [HideInInspector] public int multiplyCount;
    [HideInInspector] public GameObject Camera;
    [HideInInspector] public bool falling;
    public Rigidbody rigidbody;
    private CameraController cameraController;

    private void Awake()
    {
        cameraController = Camera.GetComponent<CameraController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            rigidbody.AddForce(new Vector3(250, 0 , 0));
        }
        if (Input.GetKeyDown("a"))
        {
            rigidbody.AddForce(new Vector3(0, 0 , 250));
        }
        if (Input.GetKeyDown("s"))
        {
            rigidbody.AddForce(new Vector3(-250, 0 , 0));
        }
        if (Input.GetKeyDown("d"))
        {
            rigidbody.AddForce(new Vector3(0, 0 , -250));
        }
        falling = rigidbody.velocity.y < 0;
        if (falling)
        {
            cameraController.LerpCameraWhileFalling();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject CollidedObject = collision.gameObject;
        if (CollidedObject.tag == "BouncingCube")
        {
            rigidbody.AddForce(new Vector3(0f, 875 * 1 + (multiplyCount / 10), 0f));
        }

        if (CollidedObject.tag == "pointCube")
        {
            multiplyCount += CollidedObject.GetComponent<PointCube>().point;
            Destroy(CollidedObject);
        }

    }


}
