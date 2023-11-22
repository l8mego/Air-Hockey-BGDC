using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField] private PuckSpawner puckSpawner;
    [SerializeField] private GameObject player;
    PaddleBehaviour playerPaddle;
    [SerializeField] private GameObject enemy;
    PaddleBehaviour enemyPaddle;

    [SerializeField] private float playerStunDuration = 1f;
    [SerializeField] private float enemyStunDuration = 1f;

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        playerPaddle = player.GetComponent<PaddleBehaviour>();
        enemyPaddle = enemy.GetComponent<PaddleBehaviour>();
    }
    public void triggerRandomPowerup()
    {
        resetPowerups();
        
        //todo: add more powerups and make it randomized
        //puckSpawner.spawnPuck();
        /*if (puckSpawner.maximumPuckReached())//for testing only
        {
            puckSpawner.clearPuck();
        }*/
        /*else
        {*/
            int randomNum = Random.Range(0, 5);
            switch (randomNum)
            {
                case 0:
                    Debug.Log("Powerups Triggered: Duplicate Puck");
                    puckSpawner.duplicatePuck();
                    break;
                case 1:
                    Debug.Log("Powerups Triggered: Player Paddle Size Up");
                    playerPaddle.paddleSizeUp();
                    break;
                case 2:
                    Debug.Log("Powerups Triggered: Enemy Paddle Size Up");
                    enemyPaddle.paddleSizeUp();
                    break;
                case 3:
                    Debug.Log("Powerups Triggered: Stun Player Paddle");
                    stunPaddle(player);
                    break;
                case 4:
                    Debug.Log("Powerups Triggered: Stun Enemy Paddle");
                    stunPaddle(enemy);
                    break;
                default:
                    Debug.Log("");
                    break;
            }
        /*}*/
    }

    void stunPaddle(GameObject paddle)
    {
        if(paddle.tag == "Player")
        {
            StartCoroutine(StunPlayer());
        }
        else if(paddle.tag == "Enemy")
        {
            StartCoroutine(StunEnemy());
        }
    }

    IEnumerator StunPlayer()
    {
        player.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePosition;
        player.GetComponent<PlayerMovement>().resetDrag();
        yield return new WaitForSeconds(playerStunDuration);
        player.GetComponent<Rigidbody2D>().constraints &= RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator StunEnemy()
    {
        enemy.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(enemyStunDuration);
        enemy.GetComponent<Rigidbody2D>().constraints &= RigidbodyConstraints2D.FreezeRotation;
    }

    void resetPowerups()
    {
        Debug.Log("Powerups Reset");
        enemyPaddle.resetSize();
        playerPaddle.resetSize();
    }
}
