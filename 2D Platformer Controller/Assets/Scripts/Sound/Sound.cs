using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{

    public string name;

    public AudioClip clip;

    [Range(0f,100f)]
    public float volume=0.5f;
    [Range(.1f,3f)]
    public float pitch=1f;
    public bool loop;

    public AudioMixerGroup mixer;

    [HideInInspector]
    public AudioSource source;
}
