using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    // choose what layermask will see the interactables
    public LayerMask interactableLayerMask = 8;
    Interactable interactable;
    public Image interactImage;
    public Sprite defaultIcon;
    public Sprite defaultInteractIcon;
    public GameObject piece;
    public AudioSource pickup;
    public AudioSource[] doorHandle;


    // Update is called once per frame
    void Update()
    {
        // create laser shooting out from camera to see interactable objects
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, interactableLayerMask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                if(interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                
                if(interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                }
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!piece.activeInHierarchy) // will need to change to a different trigger (door is always active now)
                    {
                        doorHandle[0].Play();
                        doorHandle[1].Play();
                    }
                    else
                    {
                        pickup.Play(0);
                        piece.SetActive(false);
                        //ouroborosCollected[progress].SetActive(true);
                    }
                }
            }
        }
        else
        {
            if(interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
            }
        }
    }
}
