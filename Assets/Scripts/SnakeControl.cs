using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{

    //用于储存snake的各个部位；
    public GameObject[] snake = new GameObject[1000];

    //获取snakeBody上的Rigidbody组件；
    public Rigidbody[] snakeRigi = new Rigidbody[1000];

    //用于记录snake各个部位的位置和运动方向,[ ,0]记录运动方向；
    private Vector3[,] snakePos = new Vector3[10, 2];

    //snake的长度；
    public int snakeSize;

    //记录snake的运动速度；
    public float snakeSpeed;

    private float JumpHeight;

    //记录玩家键入的方向；
    private float h;
    private float v;

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

        JumpHeight = snakeSpeed / 2;


        for (i = 1; i <= snakeSize; i++)
        {
            snakePos[i, 1] = snake[i].transform.position;

            snakePos[i, 0] = transform.right;

            snakeRigi[i] = snake[i].GetComponent<Rigidbody>();

            snakeRigi[i].velocity = Vector3.right * snakeSpeed;
        }
    }

    /// <summary>
    /// 控制snake的运动方向；
    /// </summary>
    void controlSnake()
    {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(h!=0||v!=0)
        {
            snakeRigi[1].velocity = new Vector3(h, 0, v) * snakeSpeed;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            snakeRigi[1].velocity = Vector3.up * JumpHeight;

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

            snakeRigi[i].velocity = direction * snakeSpeed;


        }
    }

}