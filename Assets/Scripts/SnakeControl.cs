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

    //记录当前snake的运动方向，防止snake反向运动,1.-1.-2.2分别表示forward，-forward，-right，right；
    private int snakeMoveDir;

    //每个body所占有的空间长度；
    private float bodySize;

    //转向时的角度误差；
    public float angleMistake;

    void Start()
    {
        initialize();

    }

    void Update()
    {
        controlSnake();
    }

    void FixedUpdate()
    {
        follow();
    }

    /// <summary>
    /// 对snake进行初始化；
    /// </summary>
    void initialize()
    {
        int i;

        snakeSize = 6;

        snakeMoveDir = 2;

        for (i = 1; i <= snakeSize; i++)
        {
            snakePos[i, 1] = snake[i].transform.position;

            snakePos[i, 0] = transform.right;
        }
       // Debug.Log(snake[1].transform.position + "1");

        //snake初始的运动方向；
        snake[1].GetComponent<Rigidbody>().velocity = transform.right * snakeSpeed;

        bodySize = Vector3.Magnitude(snake[1].transform.position - snake[2].transform.position);
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
            if(judgeDir(1))
            {
                return;
            }
            snake[1].GetComponent<Rigidbody>().velocity = new Vector3(0,0,1) * snakeSpeed;

        }
        else if (v < 0)
        {
            if (judgeDir(-1))
            {
                return;
            }
            snake[1].GetComponent<Rigidbody>().velocity = -transform.forward * snakeSpeed;
        }

        if (h>0)
        {
            if (judgeDir(2))
            {
                return;
            }
            snake[1].GetComponent<Rigidbody>().velocity = transform.right * snakeSpeed;
        }
        else if(h<0)
        {
            if (judgeDir(-2))
            {
                return;
            }

            snake[1].GetComponent<Rigidbody>().velocity = -transform.right * snakeSpeed;
        }     
    }

    //控制snake的身体跟随snake的头；
    void follow()
    {
        int i;
        //用于储存两段body之间的向量差（除去body的半径）；
        Vector3 disPos, temp;

        //用于储存disPos和snakePos[i,0]的方向向量；
        Vector3 a, b;

        //用于储存下一段body需要移动的向量；
        Vector3 movePos;

        for(i=2;i<=snakeSize;i++)
        {
            if(snakePos[1,1]==snake[1].transform.position)
            {
                return;
            }

            disPos = snake[i - 1].transform.position - snake[i].transform.position;

            a = disPos / Vector3.Magnitude(disPos); ;
            b = snakePos[i, 0] / Vector3.Magnitude(snakePos[i, 0]);

            //Debug.Log("a" + a);
            //Debug.Log("b" + b);
            //Debug.Log("<a,b>"+Vector3.Dot(a, b));

            temp = disPos;

            disPos -= a*bodySize;

            // Debug.Log(disPos+"1");
            // Debug.Log(snakePos[i,0]+"2");


            //判断向量disPos与snakePos[i,0]是否处于误差许可范围内；
            if (( Vector3.Dot(a, b)) <= angleMistake)
            {
               // Debug.Log(i + " " + snakePos[i, 0]);
               // Debug.Log(i+" "+snake[i].transform.position);

               // Debug.Log("a" + a);
                //Debug.Log(i+"b" + b);
               // Debug.Log("<a,b>"+Vector3.Dot(a, b));
                //移动下一段body对其上一段；
                temp = Vector3.Project(temp, snakePos[i, 0]);
                snake[i].transform.position += temp;


                snakePos[i, 0] = disPos;


            }

            //movePos = Vector3.Project(disPos, snakePos[i, 0]);
            movePos = snake[i - 1].transform.position - snake[i].transform.position;
            movePos -= (movePos / Vector3.Magnitude(movePos)*bodySize);


            //移动各个body的位置；
            snake[i].transform.position += movePos;

            snakePos[i, 0] = snake[i].transform.position - snakePos[i, 1];
            snakePos[i, 1] = snake[i].transform.position;

        }
    }

    /// <summary>
    /// 判断键入的方向是否与运动的反向相反；
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    bool judgeDir(int dir)
    {
        if(dir+snakeMoveDir==0)
        {
            return true;
        }
        else
        {
            snakeMoveDir = dir;

            return false;
        }
    }
}
