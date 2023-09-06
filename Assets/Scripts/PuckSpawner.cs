using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawner : MonoBehaviour
{
    [SerializeField] private const int MAX_PUCK = 8;
    [SerializeField] private GameObject puck;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(puck, transform);
        Instantiate(puck, transform);
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
            if (transform.childCount >= MAX_PUCK) return;//limit total puck
            Instantiate(puck, transform.GetChild(i).position, transform.rotation, transform);
        }
    }

    public void clearPuck()
    {
        int initialPuck = transform.childCount;
        for (int i = 0; i < initialPuck; i++) Destroy(transform.GetChild(i).gameObject);
    }

    public bool maximumPuckReached()
    {
        if (transform.childCount >= MAX_PUCK) return true;
        return false;
    }
}
