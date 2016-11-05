using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{

    //用于储存snake的各个部位；
    public GameObject[] snake = new GameObject[10];

    //用于记录snake各个部位的位置和运动方向,[ ,0]记录运动方向；
    private Vector3[,] snakePos = new Vector3[10, 3];

    //snake的长度；
    private int snakeSize;

    //记录snake的运动速度；
    public float snakeSpeed;

    void Start()
    {
        initialize();

    }

    void Update()
    {
        controlSnake();

    }

    /// <summary>
    /// 对snake进行初始化；
    /// </summary>
    void initialize()
    {
        int i;

        snakeSize = 3;

        for (i = 1; i <= snakeSize; i++)
        {
            snakePos[i, 1] = snake[i].transform.position;

            snakePos[i, 0] = transform.right;
        }

        //snake初始的运动方向；
        snake[1].GetComponent<Rigidbody>().velocity = transform.right * snakeSpeed;
    }

    /// <summary>
    /// 控制snake的运动方向；
    /// </summary>
    void controlSnake()
    {
        //用于储存玩家键入的方向；
        float v, h;

        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        //改变snake运动的方向；
        if (v > 0)
        {
            snake[1].GetComponent<Rigidbody>().velocity = transform.forward * snakeSpeed;
        }
        else if (v < 0)
        {
            snake[1].GetComponent<Rigidbody>().velocity = -transform.forward * snakeSpeed;
        }

        if (h>0)
        {
            snake[1].GetComponent<Rigidbody>().velocity = transform.right * snakeSpeed;
        }
        else if(h<0)
        {
            snake[1].GetComponent<Rigidbody>().velocity = -transform.right * snakeSpeed;
        }     
    }


}
