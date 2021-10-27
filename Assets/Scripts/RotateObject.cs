using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //private Touch touch;

    //private Vector2 touchPosition;

    //private Quaternion rotationY;

    private float rotationSpeed = 3f;

    //void Update()
    //{
    //    if(Input.touchCount > 0)
    //    {
    //        //get the first finger touch 
    //        touch = Input.GetTouch(0);

    //        if(touch.phase == TouchPhase.Moved)
    //        {
    //            rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotationSpeed, 0f);

    //            transform.rotation = rotationY * transform.rotation;
    //        }
    //    }
    //}


    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);

    }
}
