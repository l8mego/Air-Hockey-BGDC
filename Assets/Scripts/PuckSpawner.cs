using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawner : MonoBehaviour
{
    [SerializeField] GameObject puck;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(puck, transform);
        Instantiate(puck, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPuck()
    {
        Instantiate(puck, transform);
    }

    public void duplicatePuck()
    {
        int initialPuck = transform.childCount;
        for (int i = 0; i < initialPuck; i++)
        {
            Instantiate(puck, transform.GetChild(i).position, transform.rotation, transform);
        }
    }
}
