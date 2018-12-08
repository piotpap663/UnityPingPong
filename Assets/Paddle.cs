using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;
    public float width;
    string input;
    public Vector2 position;
    // Use this for initialization
    void Start()
    {
        height = transform.localScale.y;
        width = transform.localScale.x;
    }
    public void Init(bool isRightPaddle)
    {

        position = Vector2.zero;

        if (isRightPaddle)
        {
            position = new Vector2(GameManager.topRight.x, 0);
            position -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            position = new Vector2(GameManager.bottomLeft.x, 0);
            position += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";

        }

        transform.position = position;
        transform.name = input;

    }
    // Update is called once per frame
    void Update()
    {
        // GetAxis = -1 or 1
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (move < 0 && transform.position.y < GameManager.bottomLeft.y + height / 2)
        {
            move = 0;
        }
        else if (move > 0 && transform.position.y > GameManager.topRight.y - height / 2)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
