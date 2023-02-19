using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    AudioClip eat;

    [SerializeField]
    AudioClip crashWall;

    [SerializeField]
    AudioClip crashSelf;


    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySnakeSound(string otherTag) {
        if (otherTag == SnakeTag.Snake) {
            audioSource.PlayOneShot(crashSelf);
        } else if(otherTag == SnakeTag.Border) {
            audioSource.PlayOneShot(crashWall);
        } else if(otherTag == SnakeTag.Food) {
            audioSource.PlayOneShot(eat);
        }
    }
}
