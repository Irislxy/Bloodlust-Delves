using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{

    public AudioClip winSound;
    private AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null){
            Debug.Log("Error");
        }

        audioSource.clip = winSound;

        audioSource.PlayOneShot(audioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
