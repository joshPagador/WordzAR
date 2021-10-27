using IBM.Cloud.SDK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField]
    private Hit_spawner hasHIt;

    public GameObject previewModel;
    public string text;



    void Start()
    {
        hasHIt = FindObjectOfType<Hit_spawner>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            hasHIt.objHit = true;
            hasHIt.showHit(previewModel, text);
            Destroy(this.gameObject);
            FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>().word = text;

            //(1) remove comment to only have IBM S2T record when object is hit (saves cloud minutes)
            //Runnable.Run(FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>().CreateService());
            //FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>().StartRecording();

        }
    }


    //test for pc
    public void test()
    {
        hasHIt.objHit = true;
        hasHIt.showHit(previewModel, text);
        Destroy(this.gameObject);
        FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>().word = text;
        //Runnable.Run(FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>().CreateService());
        //FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>().StartRecording();
    }

}
