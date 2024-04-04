using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioSource aud;

    public AudioClip Swing_Audio;
    public AudioClip Throw_Audio;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play_swing()
    {
        aud.PlayOneShot(Swing_Audio);
    }

    public void play_throw()
    {
        aud.PlayOneShot(Throw_Audio);
    }
}
