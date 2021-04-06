using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] 
    private Transform target;

    [SerializeField] 
    private float smoothSpeed = 10f;

    [SerializeField] 
    private Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
//        transform.rotation = target.rotation;

        float RotateSpeed = 10f;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-Vector3.right * RotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
        }
        
    }




}
