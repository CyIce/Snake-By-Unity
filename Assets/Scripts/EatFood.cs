using UnityEngine;
using System.Collections;

public class EatFood : MonoBehaviour
{
    private CreateFood createFood;

    private SnakeGrow snakeGrow;

    void Start()
    {
        createFood = GameObject.Find("Main Camera").GetComponent<CreateFood>();
        snakeGrow = GameObject.Find("Main Camera").GetComponent<SnakeGrow>();

    }

    void OnTriggerEnter(Collider collider)
    {
       
        if(collider.tag=="Food")
        {
            Destroy(collider.gameObject);

            snakeGrow.snakeGrow();

            createFood.canCreate = true;
        }
    }

}
