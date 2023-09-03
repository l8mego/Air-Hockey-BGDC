using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] float currentTime = 5f;
    [SerializeField] float interval = 10f;
    [SerializeField] TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = "Timer:\n" + currentTime.ToString("0") + " S";
        if(currentTime <= 0)
        {
            //todo: trigger powerups too
            currentTime = interval;
        }
    }
}
