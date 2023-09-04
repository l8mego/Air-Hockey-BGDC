using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField] private PuckSpawner puckSpawner;

    public void triggerRandomPowerup()
    {
        //todo: add more powerups and make it randomized
        //puckSpawner.spawnPuck();
        puckSpawner.duplicatePuck();
    }
}
