using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_Player : MonoBehaviour
{
    public GameObject musicChanger;
    public GameObject[] teleporters;
    public GameObject Enemy;
    public BoxCollider killZone;
    public GameObject Player;
    public GameObject piece;
    public Transform[] points;
    public float speed;
    public float delayTime;
    public bool chase;
    public AudioSource monsterAudio;
    int current;
    bool resume;
    Animator enemyAnim;
    //Quaternion rotation;


    void Start()
    {
        current = 0;
        chase = false;
        resume = false;
        enemyAnim = Enemy.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(piece.activeInHierarchy)
            {
                chase = true;
                teleporters[0].SetActive(false);
                teleporters[1].SetActive(false);
                killZone.enabled = true;
                musicChanger.SetActive(true);
                enemyAnim.SetBool("Chasing", true);
                monsterAudio.enabled = true;
            }
        }
    }

    IEnumerator Delay_Action(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        resume = true;
    }

    void Update()
    {
        // once player exits room, enemy will chase
        if(chase)
        {
            // if the enemy is not at his end point
            if(current < 3)
            {
                if(current < 1) 
                {
                // if enemy is not at the currently targeted point
                    if(Enemy.transform.position != points[current].position)
                    {
                        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, points[current].position, speed * Time.deltaTime);
                        print(current);
                    }
                    else
                    {
                        // if player is to the left of the enemy, turn left (instead of right)
                        if(Player.transform.position.z < points[current].position.z)
                        {
                            current += 1; 
                        }
                        current += 1;
                        //rotation = Quaternion.FromToRotation(Enemy.transform.forward, points[current].position - Enemy.transform.position);
                    }
                }
                else 
                {
                    Enemy.transform.rotation = Quaternion.RotateTowards(Enemy.transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), (speed * 50) * Time.deltaTime);
                    StartCoroutine(Delay_Action(delayTime));
                    if(resume == true)
                    {
                        print("resume == true");
                        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, points[current].position, (speed * 5) * Time.deltaTime);
                    }

                }
            }
        }
    }
}
