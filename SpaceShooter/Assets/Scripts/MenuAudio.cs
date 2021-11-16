using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource menuAudio;
    void Awake(){
        menuAudio = GetComponent<AudioSource>();
         menuAudio.Play();
    }
    void Start()
    {
        menuAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
