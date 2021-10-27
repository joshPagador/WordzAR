using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{

    // Orbit max Speed
    //public float maxOrbitSpeed = 3f;

    // Orbit speed
    private float orbitSpeed = 10f;

    // Anchor point for the Cube to rotate around
    private Transform anchor;

    // Orbit direction
    private Vector3 dir;

    void Start()
    {
        ChangeCubes();
    }

    void Update()
    {
        CubeRotate();   
    }

    private void CubeRotate()
    {
        // rotate cube around camera
        transform.RotateAround(anchor.position, dir, orbitSpeed * Time.deltaTime);

        // rotating around its axis
        transform.Rotate(dir * 30 * Time.deltaTime);
    }


    // Set initial cube settings
    private void ChangeCubes()
    {
        // defining the anchor point as the main camera
        anchor = Camera.main.transform;

        // defining the orbit direction
        float x = UnityEngine.Random.Range(-1f, 1f);
        float y = UnityEngine.Random.Range(-1f, 1f);
        float z = UnityEngine.Random.Range(-1f, 1f);
        dir = new Vector3(x, y, z);

        // defining speed
        //orbitSpeed = UnityEngine.Random.Range(1, maxOrbitSpeed);
    }
}
