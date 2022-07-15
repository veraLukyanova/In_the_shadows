using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public AudioSource PlaySounds;
    public AudioClip hoverSounds;
    public AudioClip clickSounds;

    public void HoverSound()
    {
        PlaySounds.PlayOneShot(hoverSounds);
    }

    public void ClickSound()
    {
        PlaySounds.PlayOneShot(clickSounds);
    }
}
