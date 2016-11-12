using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public GameObject otherPortal;

    private Vector3 NewPos;

    private float snakeHight = 0.5f;

    void Start()
    {
        NewPos = otherPortal.transform.position;

        NewPos.y = snakeHight;
    }

	void Update ()
    {
	    
	}
    void OnTriggerStay(Collider collider)
    {
        if(collider.tag=="SnakeBody")
        {
            collider.gameObject.transform.position = NewPos;
        }
    }
}
