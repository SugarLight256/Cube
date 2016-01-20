using UnityEngine;
using System.Collections;

public class cubeManager : MonoBehaviour {

    public static int boxSize;
    private int cubeCount;
    public GameObject[] cubes;
    public GameObject Poal;

	// Use this for initialization
	void Start () {
        boxSize = 3;
        cubeCount = boxSize * boxSize * boxSize;
        cubes = new GameObject[cubeCount];
	    for(int i=0; i<cubeCount; i++)
        {
            //cubes[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Poal.transform.RotateAround(new Vector3(2,1.5f,1.5f), new Vector3(1,0,0), 1);
	}

    public void setPoalObject()
    {
        
    }

}
