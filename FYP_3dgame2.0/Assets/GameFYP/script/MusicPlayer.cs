using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject bgMusic;

    private float musicVolume = 1f;

    private void Start()
    {
        bgMusic.SetActive(true);
        audioSource.Play();
    }
    private void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
