using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MusicHandler : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;

    public IEnumerator PlayAndDeleteAudio(double distance)
    { 
        if (distance < 10000)
        {
            audioSource = GetComponent<AudioSource>();
            //play audio till the end and then stop it
            yield return StartCoroutine(GetIziAudio.GetAudioClip());
            audioClip = GetIziAudio.IziClip;
            audioSource.clip = audioClip;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
            Destroy(audioSource);
        }
        if (distance > 250000 && audioSource != null) audioSource.Stop(); //if you went too far, you're not intrested in this audio anymore
    }

}
