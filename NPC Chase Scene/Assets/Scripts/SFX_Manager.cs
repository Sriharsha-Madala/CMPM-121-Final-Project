using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public GameObject musicChanger;
    public Interactor interactor;
    public AudioSource creeking;
    public AudioSource[] ambience;
    // Start is called before the first frame update
    void Start()
    {
        creeking.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // enable / disable creeking sound depending on room
        if(interactor.progress == 0 || interactor.progress == 5)
        {
            creeking.enabled = false;
        }
        else
        {
            creeking.enabled = true;
        }

        // enable / disable ambience track depending on progress
        if(interactor.progress == 1)
        {
            ambience[0].enabled = false;
            ambience[1].enabled = true;
        }
        else if(interactor.progress == 3)
        {
            ambience[1].enabled = false;
            ambience[2].enabled = true;
        }
        else if(interactor.progress == 5 && musicChanger.activeInHierarchy)
        {
            ambience[2].enabled = false;
            ambience[3].enabled = true;
        }

    }
}
