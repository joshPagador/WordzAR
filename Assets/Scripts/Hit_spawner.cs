using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_spawner : MonoBehaviour
{

    public GameObject passUI;

    public GameObject bow;

    public GameObject menuButton;

    public Transform spawnLocation;

    public bool objHit = false;

    public bool hasSpawned = false;

    private Shoot shoot;

    [SerializeField]
    private IBM.Watsson.Examples.ExampleStreaming speechToText;

    private Animator bowAnim;


    // Start is called before the first frame update
    void Start()
    {
        shoot = FindObjectOfType<Shoot>();

        speechToText = FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>();

        bowAnim = bow.GetComponent<Animator>();

        //(1) remove comment to only have IBM S2T record when object is hit (saves cloud minutes)
        //speechToText.StartRecording();
        //speechToText.StopRecording();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (objHit == true)
        {
            //(1) remove comment to only have IBM S2T record when object is hit (saves cloud minutes)
            // if(!speechToText.Active)
            //speechToText.StartRecording();

        }
        else
        {
            //(1) remove comment to only have IBM S2T record when object is hit (saves cloud minutes)
            //if (speechToText.Active)
                //speechToText.StopRecording();
        }



        if (objHit == false && !shoot.enabled)
        {
            bowAnim.SetBool("Bow", false);
            shoot.enabled = true;
            GameObject objectToDestroy = GameObject.FindGameObjectWithTag("Object");
            Destroy(objectToDestroy, 1f);
            //(1) remove comment to only have IBM S2T record when object is hit (saves cloud minutes)
            //speechToText.StopRecording();


            //checks if no floating objects remain so the passUI can show up
            if (FindObjectOfType<ObjectBehaviour>() == null)
            {
                passUI.SetActive(true);
                bow.SetActive(false);
                menuButton.SetActive(false);
            }
        }
        


    }

    public void showHit(GameObject spawnObj, string text)
    {
        hasSpawned = true;
        //bow.SetActive(false);
        bowAnim.SetBool("Bow", true);
        shoot.enabled = false;
        GameObject obj = Instantiate(spawnObj, spawnLocation.position, spawnLocation.rotation);
        obj.transform.parent = spawnLocation.transform;
        //(1) remove comment to only have IBM S2T record when object is hit (saves cloud minutes)
        //speechToText.StartRecording();
    }

}
