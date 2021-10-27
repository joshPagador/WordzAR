using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] cubeObjects;

    public float timeToSpawn = 1f;

    private GameObject[] cubes;

    private bool setPosition;

    private ARCameraManager cam;


    void Start()
    {
        cam = FindObjectOfType<ARCameraManager>();

        StartCoroutine(SpawnLoop());

        cubes = new GameObject[cubeObjects.Length];
    }

    // Loop Spawning cube elements
    private IEnumerator SpawnLoop()
    {
        // Defining the Spawning Position
        StartCoroutine(ChangePosition());

        yield return new WaitForSeconds(2f);

        // Spawning the elements
        int i = 0;
        while (i <= (cubeObjects.Length-1))
        {

            cubes[i] = SpawnElement(i);
            i++;
            yield return new WaitForSeconds(Random.Range(timeToSpawn, timeToSpawn * 3));
        }
    }

    // Spawn a cube
    private GameObject SpawnElement(int i)
    {
        // spawn the element on a random position, inside a imaginary sphere
        GameObject cube = Instantiate(cubeObjects[i], (Random.insideUnitSphere * 4) + transform.position, transform.rotation) as GameObject;
        // define a random scale for the cube
        float scale = Random.Range(1.5f, 2f);
        // change the cube scale
        cube.transform.localScale = new Vector3(scale, scale, scale);
        return cube;
    }


    // define position of object spawn area according to ar camera pos
    private bool SetPosition()
    {
        Transform cam = Camera.main.transform;
        //set position x units forward from camera position
        transform.position = cam.forward * 15;
        return true;
    }



    private IEnumerator ChangePosition()
    {

        yield return new WaitForSeconds(0.2f);
        // define spawn pos onnce
        if(!setPosition)
        {
            // change position if camera script is enabled
            if(cam.enabled)
            {
                SetPosition();
            }
        }
    }

}
