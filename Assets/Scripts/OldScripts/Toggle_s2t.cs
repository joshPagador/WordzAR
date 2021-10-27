using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Cloud.SDK.Utilities;

public class Toggle_s2t : MonoBehaviour
{

    [SerializeField]
    private IBM.Watsson.Examples.ExampleStreaming speechToText;

    bool active = false;

    [SerializeField]
    private Button button;

    [SerializeField]
    private Text text;


    // Start is called before the first frame update
    void Start()
    {
        speechToText = FindObjectOfType<IBM.Watsson.Examples.ExampleStreaming>();

        button = GameObject.Find("s2tbutton").GetComponent<Button>();

        text = GameObject.Find("s2ttext").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //turn on speach to text and start/stop ibm listener
    public void ToggleSpeechToText()
    {
        active = !active;

        if (active)
        {
            button.image.color = Color.green;
            text.text = "Listening... ";
            Runnable.Run(speechToText.CreateService());
            speechToText.StartRecording();
        }
        else if (!active)
        {
            button.image.color = Color.white;
            text.text = "Test";
            speechToText.StopRecording();
        }
    }
}
