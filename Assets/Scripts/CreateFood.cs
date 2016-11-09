using UnityEngine;
using System.Collections;

public class CreateFood : MonoBehaviour {

    public GameObject food;

    //地图的大小；
    public float mapLenght;
    public float mapBreadth;
    public float mapHeight;

    public bool canCreate;

	void Start ()
    {
        canCreate = true;
	}
	
	void Update ()
    {
	    if(canCreate)
        {
            Vector3 foodDir = new Vector3
                (Random.Range(-mapBreadth, mapBreadth),
                 Random.Range(0, mapHeight),
                 Random.Range(-mapLenght, mapLenght));

            Instantiate(food, foodDir, Quaternion.identity);

            canCreate = false;

        }
	}
}
