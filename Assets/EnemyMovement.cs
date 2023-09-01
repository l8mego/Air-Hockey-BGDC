using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 1000f;
    Rigidbody2D rb2d;
    SpriteRenderer sRenderer;

    [SerializeField] private SpriteRenderer area;
    [SerializeField] private Rigidbody2D puck;
    Vector2 targetPos;
    float starterY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = 0f;
        if(puck.position.y < (area.transform.position.y - (area.bounds.size.y/2)))
        {
            speed = maxSpeed * 0.5f;
            targetPos = new Vector2(Mathf.Clamp(puck.position.x, 
                area.transform.position.x - (area.bounds.size.x / 2),
                area.transform.position.x + (area.bounds.size.x / 2)), starterY);
        }
        else
        {
            speed = maxSpeed;
            targetPos = new Vector2(Mathf.Clamp(puck.position.x,
                area.transform.position.x - (area.bounds.size.x / 2),
                area.transform.position.x + (area.bounds.size.x / 2)), 
                Mathf.Clamp(puck.position.y, 
                area.transform.position.y - (area.bounds.size.y / 2),
                area.transform.position.y + (area.bounds.size.y / 2)));
        }
        rb2d.MovePosition(Vector2.MoveTowards(rb2d.position, targetPos, speed));

    }
}
