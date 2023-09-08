using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    Transform paddleTransform;
    
    // Start is called before the first frame update

    private void Start()
    {
        paddleTransform = GetComponent<Transform>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Puck")
        {
            //if (!sfx.isPlaying){
            sfx.Play(0);
            //}
        }
    }

    public void paddleSizeUp()
    {
        paddleTransform.localScale += new Vector3(1f, 1f);
    }

    public void resetSize()
    {
        paddleTransform.localScale = new Vector3(3f, 3f, 1f);
    }

    // Update is called once per frame
}
