using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject bumperSFXAudioSource;
    public GameObject switchSFXAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlayBumperSFX(Vector3 spawnPos)
    {
        GameObject.Instantiate(bumperSFXAudioSource, spawnPos, Quaternion.identity);
    }

    public void PlaySwitchSFX(Vector3 spawnPos)
    {
        GameObject.Instantiate(switchSFXAudioSource, spawnPos, Quaternion.identity);
    }
}
