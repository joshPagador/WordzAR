using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;

    [SerializeField]
    private AudioClip buttonSound;

    private AudioSource audioSource;

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicVol", volume);
        audioMixer.SetFloat("musicVol", Mathf.Log10(volume) * 20);
    }

    public void SetSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxVol", volume);
        audioMixer.SetFloat("sfxVol", Mathf.Log10(volume) * 20);
    }

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        musicSlider.value = PlayerPrefs.GetFloat("musicVol", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol", 1f);
    }

    public void SoundOnPress()
    {
        audioSource.PlayOneShot(buttonSound);
    }

}
