using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public GameObject otherPortal;

    private Vector3 NewPos;


    //另一个Portal上的脚本；
    private Portal portal;

    private float snakeHight = 0.5f;

    void Start()
    {
        

        portal = otherPortal.GetComponent<Portal>();

        NewPos = otherPortal.transform.position;

        NewPos.y = snakeHight;
        portal.enabled = false;
    }

	void Update ()
    {
	    
	}
    void OnTriggerStay(Collider collider)
    {
        if(collider.tag=="SnakeBody")
        {
            //portal.enabled = false;

            collider.gameObject.transform.position = NewPos;
        }
    }
}
