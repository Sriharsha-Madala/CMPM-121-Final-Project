using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Player : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    public GameObject Enemy;
    public Interactor interactor;
    public GameObject[] rooms;
    public GameObject CollectedLastPiece;
    public GameObject door1;
    public GameObject door2;
    public GameObject hallOff;
    public GameObject HallOn;
    public GameObject pedestalOff;

    
    void OnTriggerEnter(Collider other)
    {
        // teleport player to opposite side
        player.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            teleportTarget.transform.position.z
        );

        // change rooms if player collected oroboros piece
        if(interactor.changeRoom && interactor.progress != 5)
        {
            rooms[interactor.progress].SetActive(false);
            interactor.progress += 1;
            
            //once last room is reached, spawn enemy
            if(interactor.progress == 5)
            {
                Enemy.SetActive(true);
            }
            rooms[interactor.progress].SetActive(true);
            interactor.ouroboros[interactor.progress].SetActive(true);
            interactor.changeRoom = false;
        }

    }

    void Update()
    {
        // spawn end doors once player collects final oroboros piece
        if(CollectedLastPiece.activeInHierarchy)
        {
            door1.SetActive(true);
            door2.SetActive(true);
            hallOff.SetActive(false);
            HallOn.SetActive(true);
            pedestalOff.SetActive(false);
        }
    }
}
