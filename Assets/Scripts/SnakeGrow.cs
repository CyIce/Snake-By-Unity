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

        bodyPos = snakeControl.snake[size].transform.position;

        //生成新的body；
        Instantiate(body, bodyPos, Quaternion.identity);

        snakeControl.snakeSize++;
    }
}
