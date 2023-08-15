using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D col2d;
    Camera mainCam;
    bool isDragged = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        isDragged = true;
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            rb2d.MovePosition(mousePos);
        }
    }
}
