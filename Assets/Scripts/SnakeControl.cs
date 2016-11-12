using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{

    //用于储存snake的各个部位；
    public GameObject[] snake = new GameObject[1000];

    //获取snakeBody上的Rigidbody组件；
    public Rigidbody[] snakeRigi = new Rigidbody[1000];

    //snake的长度；
    public int snakeSize = 3;

    //记录snake的运动速度；
    public float snakeSpeed;
    //记录snake的跳跃高度；
    private float JumpHeight;

    //记录portal之间的距离；
    public float PortalDistance = 5f;

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
        Debug.Log(snakeRigi[1].velocity);

        controlSnake();

        follow();
    }

    /// <summary>
    /// 对snake进行初始化；
    /// </summary>
    void initialize()
    {
        JumpHeight = snakeSpeed / 2;

        for (int i = 1; i <= snakeSize; i++)
        {
            snakeRigi[i] = snake[i].GetComponent<Rigidbody>();

            snakeRigi[i].velocity = Vector3.right * snakeSpeed;
        }
    }

    /// <summary>
    /// 控制snake的运动方向；
    /// </summary>
    void controlSnake()
    {
        //用于储存snakeHead的运动速度；
        Vector3 moveVec;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(h!=0||v!=0)
        {
            //固定snakeHead的运动速率为snakeSpeed；
            moveVec = new Vector3(h, 0, v);
            moveVec = Vector3.Normalize(moveVec) * snakeSpeed;

            snakeRigi[1].velocity = moveVec;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            moveVec = snakeRigi[1].velocity+Vector3.up*JumpHeight;
            moveVec = Vector3.Normalize(moveVec) * snakeSpeed;

            snakeRigi[1].velocity = moveVec;

        }


    }


    /// <summary>
    /// 控制snake的身体跟随snake的头；
    /// </summary>
    void follow()
    {

        //用于记录每个body运动的方向；
        Vector3 direction;

        for (int i = 2; i <= snakeSize; i++)
        {
            //lastSpeed = Vector3.Magnitude(snakeRigi[i - 1].velocity);

            direction = snake[i - 1].transform.position - snake[i].transform.position;

            if(Vector3.Magnitude(direction)<PortalDistance)
            {
                direction = Vector3.Normalize(direction);
                snakeRigi[i].velocity = direction * snakeSpeed;
            }

        }
    }

}