using UnityEngine;
using System.Collections;

public class SnakeGrow : MonoBehaviour
{

    private SnakeControl snakeControl;

    public GameObject body;

    void Start()
    {
        snakeControl = GetComponent<SnakeControl>();
    }

    /// <summary>
    /// 生成新的body；
    /// </summary>
    public void snakeGrow()
    {
        //snake的长度；
        int size;

        Vector3 bodyPos;

        size = snakeControl.snakeSize;

        bodyPos = 2 * snakeControl.snake[size].transform.position -
                      snakeControl.snake[size - 1].transform.position;


        snakeControl.snakeSize++;
        //生成新的body；
        snakeControl.snake[size+1]=Instantiate(body);

        snakeControl.snake[size + 1].transform.position = bodyPos;


        
    }
}
