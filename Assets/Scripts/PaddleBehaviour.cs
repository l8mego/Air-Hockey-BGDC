using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Puck")
        {
            //if (!sfx.isPlaying){
                sfx.Play(0);
            //}
        }
    }

    // Update is called once per frame

}
