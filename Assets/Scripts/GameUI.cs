using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    float oldTime;
    [SerializeField] float currentTime = 5f;
    [SerializeField] float interval = 10f;
    [SerializeField] TMP_Text timeText;
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
            //todo: trigger powerups too
            currentTime = interval;
        }
    }
}
