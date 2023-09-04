using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    float oldTime;
    [SerializeField] private Powerups powerup;
    [SerializeField] private float currentTime = 5f;
    [SerializeField] private float interval = 10f;
    [SerializeField] private TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Timer:\n" + currentTime.ToString("0") + " S";
        oldTime = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = timeText.text.Replace(oldTime.ToString("0"), currentTime.ToString("0"));
        oldTime = currentTime;
        if (currentTime <= 0)
        {
            powerup.triggerRandomPowerup();
            currentTime = interval;
        }
    }
}
