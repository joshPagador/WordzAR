using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_bt : MonoBehaviour
{
    public GameObject spawnButton;
    public GameObject voiceButton;

    //test
    public GameObject shootButton;

    public void OpenButtons()
    {
        if(spawnButton && voiceButton && shootButton !=null)
        {
            Animator animator = spawnButton.GetComponent<Animator>();
            Animator animator_2 = voiceButton.GetComponent<Animator>();
            Animator animator_3 = shootButton.GetComponent<Animator>();
            if (animator && animator_2 && animator_3 != null)
            {
                bool isOpen = animator.GetBool("Open");
                bool isOpen_2 = animator.GetBool("Open");
                bool isOpen_3 = animator.GetBool("Open");

                animator.SetBool("Open", !isOpen);
                animator_2.SetBool("Open", !isOpen);
                animator_3.SetBool("Open", !isOpen);
            }
        }
    }
}
