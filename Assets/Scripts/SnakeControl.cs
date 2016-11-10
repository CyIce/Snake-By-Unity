using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{

    //用于储存snake的各个部位；
    public GameObject[] snake = new GameObject[10];

    //用于记录snake各个部位的位置和运动方向,[ ,0]记录运动方向；
    private Vector3[,] snakePos = new Vector3[10, 2];

    //snake的长度；
    public int snakeSize;

    //记录snake的运动速度；
    public float snakeSpeed;

    //记录snake移动的方向,上下左右分别为1、2、3、4,0表示跳跃；
    private int snakeMoveDir;

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

        snakeMoveDir = 4;


        for (i = 1; i <= snakeSize; i++)
        {
            snakePos[i, 1] = snake[i].transform.position;

            snakePos[i, 0] = transform.right;

            snake[i].GetComponent<Rigidbody>().velocity = Vector3.right * snakeSpeed;
        }
    }

    /// <summary>
    /// 控制snake的运动方向；
    /// </summary>
    void controlSnake()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && snakeMoveDir != 2)
        {
            snake[1].GetComponent<Rigidbody>().velocity = Vector3.forward * snakeSpeed;

            snakeMoveDir = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && snakeMoveDir != 1)
        {
            snake[1].GetComponent<Rigidbody>().velocity = Vector3.back * snakeSpeed;

            snakeMoveDir = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && snakeMoveDir != 4)
        {
            snake[1].GetComponent<Rigidbody>().velocity = Vector3.left * snakeSpeed;

            snakeMoveDir = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && snakeMoveDir != 3)
        {
            snake[1].GetComponent<Rigidbody>().velocity = Vector3.right * snakeSpeed;

            snakeMoveDir = 4;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            snake[1].GetComponent<Rigidbody>().velocity = Vector3.up * snakeSpeed;

            snakeMoveDir = 0;
        }
    }

    //控制snake的身体跟随snake的头；
    void follow()
    {

        //用于记录每个body运动的方向；
        Vector3 direction;

        for (int i = 2; i <= snakeSize; i++)
        {
            direction = snake[i - 1].transform.position - snake[i].transform.position;

            direction = (direction / Vector3.Magnitude(direction));

            snake[i].GetComponent<Rigidbody>().velocity = direction * snakeSpeed;


        }
    }

}