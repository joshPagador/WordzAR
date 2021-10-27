using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minLogoTime = 3.0f;

    private void Start()
    {
        //look for an object with canvas group in scene and store it in variable
        fadeGroup = FindObjectOfType<CanvasGroup>();
        //set variables object type canvasgroup to alpha 1
        fadeGroup.alpha = 1;

        //get timestamp of completion time
        if(Time.time < minLogoTime)
        {
            loadTime = minLogoTime;
        }
        else
        {
            loadTime = Time.time;
        }
    }


    private void Update()
    {
        if(Time.time < minLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        //fade out
        if(Time.time > minLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minLogoTime;
            if(fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }





}
