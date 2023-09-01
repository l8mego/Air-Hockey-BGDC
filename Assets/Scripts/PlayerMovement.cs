using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D col2d;
    SpriteRenderer sRenderer;
    Camera mainCam;
    bool isDragged = false;

    [SerializeField] private SpriteRenderer bg;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
    }



    void OnMouseDown()
    {
        isDragged = true;
    }

    void OnMouseUp()
    {
        isDragged = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            // - (sRenderer.bounds.size.x / 2)
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = Mathf.Clamp(mousePos.x, bg.transform.position.x - (bg.bounds.size.x / 2),
                bg.transform.position.x + (bg.bounds.size.x/2));
            mousePos.y = Mathf.Clamp(mousePos.y, bg.transform.position.y - (bg.bounds.size.y / 2),
                bg.transform.position.y + (bg.bounds.size.y/2));
            /*Debug.Log("Mouse Pos" + mousePos);
            Debug.Log("Transform Pos" + bg.transform.position);
            Debug.Log("Bound size" + bg.bounds.size);*/
            rb2d.MovePosition(mousePos);
        }
    }
}
