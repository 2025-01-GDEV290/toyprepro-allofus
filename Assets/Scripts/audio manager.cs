using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;

    public AudioSource audio_source;
    public AudioClip hit_sound;
    public AudioClip break_sound;

    void Start()
    {
        instance = this;

        audio_source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void onHitSound()
    {
        audio_source.clip = hit_sound;
        audio_source.Play();

    }

    public void onBreakSound()
    {
        audio_source.clip = break_sound;
        audio_source.Play();

    }
}
