using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{

    //用于储存snake的各个部位；
    public GameObject[] snake = new GameObject[10];

    //用于记录snake各个部位的位置和运动方向,[ ,0]记录运动方向；
    private Vector3[,] snakePos = new Vector3[10, 2];

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

        follow();

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

    //控制snake的身体跟随snake的头；
    void follow()
    {
        int i;
        //用于储存两段body之间的向量差（除去body的半径）；
        Vector3 disPos;

        //用于储存下一段body需要移动的向量；
        Vector3 movePos;

        for(i=2;i<=snakeSize;i++)
        {
            disPos = snake[i - 1].transform.position - snake[i].transform.position;

            disPos -= (disPos / Vector3.Magnitude(disPos));

            movePos = Vector3.Project(disPos, snakePos[i, 0]);

            //移动各个body的位置；
            snake[i].transform.position += movePos;

            snakePos[i, 0] = snake[i].transform.position - snakePos[i, 1];
            snakePos[i, 1] = snake[i].transform.position;

        }



    }

}
