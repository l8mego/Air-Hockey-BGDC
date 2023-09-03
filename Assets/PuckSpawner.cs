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
        Instantiate(puck, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
