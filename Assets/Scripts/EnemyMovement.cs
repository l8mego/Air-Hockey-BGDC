using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 1000f;
    Rigidbody2D rb2d;
    SpriteRenderer sRenderer;

    [SerializeField] private SpriteRenderer area;
    [SerializeField] private GameObject puckSpawner;
    Vector2 targetPos;
    float starterY = 35f;
    bool isStunned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStunned) return;
        if (puckSpawner.transform.childCount <= 0) return;
        Rigidbody2D puck = findNearestPuck();
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
        rb2d.MovePosition(Vector2.MoveTowards(rb2d.position, targetPos, speed * Time.fixedDeltaTime));

    }

    Rigidbody2D findNearestPuck()//ganti aja kalo ada cara yang lebih efisien
    {
        int index = 0;
        float nearestPuck = Vector2.Distance(puckSpawner.transform.GetChild(0).position, transform.position);
        
        for (int i = 1; i < puckSpawner.transform.childCount; i++)
        {
            float distance = Vector2.Distance(puckSpawner.transform.GetChild(i).position, transform.position);
            if (nearestPuck > distance)
            {
                index = i;
                nearestPuck = distance;
            }
        }
        return (puckSpawner.transform.GetChild(index).GetComponent<Rigidbody2D>());
    }

    public void setStun(bool stunState)
    {
        isStunned = stunState;
    }
}
