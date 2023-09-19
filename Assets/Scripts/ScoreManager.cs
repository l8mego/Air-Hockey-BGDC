using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text score1;
    int scorePl1 = 0;
    int scorePl2 = 0;
    private void Awake() {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        score1.text = "Score\n" + scorePl1.ToString() + ":" + scorePl2.ToString();
    }

    // Update is called once per frame

    public void Addscore1()
    {
        scorePl1 += 1;
        score1.text = "Score\n" + scorePl1.ToString() + ":" + scorePl2.ToString();
    }
    public void Addscore2(){
        scorePl2 += 1;
        score1.text = "Score\n" + scorePl1.ToString() + ":" + scorePl2.ToString();
    }

    
}
