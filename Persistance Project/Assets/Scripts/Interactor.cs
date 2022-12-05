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
    public GameObject[] ouroboros;
    public GameObject[] ouroborosCollected;
    public GameObject endDoor;
    public bool changeRoom = false;
    public int progress = 0;
    public AudioSource pickup;
    public AudioSource doorHandle;
    public AudioSource ding;


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
                    if(endDoor.activeInHierarchy)
                    {
                        doorHandle.Play();
                    }
                    else
                    {
                        pickup.Play(0);
                        changeRoom = true;
                        ouroboros[progress].SetActive(false);
                        ouroborosCollected[progress].SetActive(true);
                        ding.Play();
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
