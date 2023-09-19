using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckhole : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Puck"){
            Debug.Log("Entered");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Entered");
        if(other.tag =="Puck"){
            ScoreManager.instance.Addscore1();
        }
        
    }
}
