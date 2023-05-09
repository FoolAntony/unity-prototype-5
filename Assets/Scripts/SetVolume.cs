using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        slider.value = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        SetLevel();
    }

    public void SetLevel ()
    {
        audioSource.volume = slider.value;
    }
}

