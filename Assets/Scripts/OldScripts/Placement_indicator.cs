using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class Placement_indicator : MonoBehaviour
{

    private ARRaycastManager raymanager;
    private GameObject visual;

    void Start()
    {
        //Get components
        raymanager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        //hide the placement visual
        visual.SetActive(false);
    }


    void Update()
    {
        //Shoot raycast from center of screen
        List<ARRaycastHit> hit = new List<ARRaycastHit>();
        raymanager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hit, TrackableType.Planes);

        //if hit AR Plane, update position and rotation
        if(hit.Count > 0)
        {
            transform.position = hit[0].pose.position;
            transform.rotation = hit[0].pose.rotation;

            if(!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }
}
