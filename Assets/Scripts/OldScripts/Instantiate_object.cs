using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_object : MonoBehaviour
{

    public GameObject objectToSpawn;

    private Placement_indicator placementIndicator;



    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<Placement_indicator>();
    }

    // Update is called once per frame
    void Update()
    {

        //screen touch to spawn object
        //if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        //}
    }

    //function called when pressing onscreen button
    public void SpawnObject()
    {    
        GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation); 
    }
}
