using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneChanger : MonoBehaviour
{
    //animation for fading between scenes
    public Animator transition;

    public float transitionTimer = 1f;

    public void EnterScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTimer);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
