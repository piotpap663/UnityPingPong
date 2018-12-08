using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector2 direction;
    float radius;
    float velocity;
    // Use this for initialization
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
        velocity = (float)0.1;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.y < 0 && transform.position.y < GameManager.bottomLeft.y + radius)
        {

            direction.y = -direction.y;
        }
        else if (direction.y > 0 && transform.position.y > GameManager.topRight.y - radius)
        {
            direction.y = -direction.y;
        }

        // Game over

        if (direction.x < 0 && transform.position.x < GameManager.bottomLeft.x + radius)
        {
            GameOver("Right");
        }
        else if (direction.x > 0 && transform.position.x > GameManager.topRight.x - radius)
        {
            GameOver("Left");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        float paddlePosx = other.GetComponent<Paddle>().position.x;
        float paddleWidth = other.GetComponent<Paddle>().width / 4;

        if (other.tag == "Paddle" && transform.position.x + radius > paddlePosx && direction.x > 0)
        {
            GameOver("Left");
        }
        else if (other.tag == "Paddle" && transform.position.x - radius < paddlePosx && direction.x < 0)
        {
            GameOver("Right");
        }
        else if (other.tag == "Paddle")
        {

            direction.x = -direction.x;

        }
        if (direction.y > 0)
        {
            direction.y += velocity;

        }
        else
        {

            direction.y -= velocity;
        }


    }
    void GameOver(string winner)
    {
        Debug.Log(winner + " wins");
        Time.timeScale = 0;
        enabled = false;

    }
}
