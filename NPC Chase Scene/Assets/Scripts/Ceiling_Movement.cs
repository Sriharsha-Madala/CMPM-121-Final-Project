using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling_Movement : MonoBehaviour
{
    public GameObject[] ouroborosCollected;
    public Transform[] points;
    public float speed;
    int current;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(current <= 5)
        {
            if(ouroborosCollected[current].activeInHierarchy)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, points[current].position, speed * Time.deltaTime);
            }
            if(this.transform.position == points[current].position)
            {
                current += 1;
            }
        }
    }
}
