using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public GameObject musicChanger;
    public AudioSource[] ambience;

    // Update is called once per frame
    void Update()
    {
        // enable / disable ambience track depending on progress
        if(!musicChanger.activeInHierarchy)
        {
            ambience[0].enabled = true;
            ambience[1].enabled = false;
        }
        else
        {
            ambience[0].enabled = false;
            ambience[1].enabled = true;
        }

    }
}
