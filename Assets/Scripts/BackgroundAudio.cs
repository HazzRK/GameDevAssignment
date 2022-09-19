using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip ghostNormalClip;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        GetComponent<AudioSource>().loop = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = ghostNormalClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
