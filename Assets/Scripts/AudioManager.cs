using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

     void Awake()
    {
        foreach (Sound s in sounds)
        {
          s.source =  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    public void Play()
    {
       Sound s= Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    internal void Play(string v)
    {
        throw new NotImplementedException();
    }
}
