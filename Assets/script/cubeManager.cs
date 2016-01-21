using UnityEngine;
using System.Collections;

public class cubeManager : MonoBehaviour {

    public static int boxSize;
    private int cubeCount;
    private int deg = 0;
    private bool rotFlag;
    private Vector3 axis;
    private Vector3 point;
    public GameObject[] cubes;

    public GameObject[] rotCubes = new GameObject[9];

    public BoxCollider Right;
    public BoxCollider Left;
    public BoxCollider Forwerd;
    public BoxCollider Back;
    public BoxCollider Up;
    public BoxCollider Down;

	// Use this for initialization
	void Start () {

        boxSize = 3;
        cubeCount = boxSize * boxSize * boxSize;
        cubes = new GameObject[cubeCount];
	    for(int i=0; i<cubeCount; i++)
        {
            cubes[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(!rotFlag && (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.D)))
        {
            keyToDir(Input.inputString[0]);
        }
        if (rotFlag && deg < 90*9)
        {
            for (int i = 0; i < 9; i++)
            {
                rotCubes[i].transform.RotateAround(point, axis, 1.0f);
                deg++;
            }
        }
        else
        {
            rotFlag = false;
            rotCubes = null;
            deg = 0;
        }
	}

    private void keyToDir(char key)
    {
        switch (key)
        {
            case 'R':
                axis = new Vector3(1, 0, 0);
                Rotation(Right);
                break;
            case 'L':
                axis = new Vector3(1, 0, 0);
                Rotation(Left);
                break;
            case 'F':
                axis = new Vector3(0, 0, 1);
                Rotation(Forwerd);
                break;
            case 'B':
                axis = new Vector3(0, 0, 1);
                Rotation(Back);
                break;
            case 'U':
                axis = new Vector3(0, 1, 0);
                Rotation(Up);
                break;
            case 'D':
                axis = new Vector3(0, 1, 0);
                Rotation(Down);
                break;
        }
    }

    private void Rotation(BoxCollider collid)
    {
        Collider[] tmpColl = Physics.OverlapBox(collid.transform.position, collid.size/2);
        point = collid.transform.position;
        rotCubes = new GameObject[9];
        for (int i = 0; i < tmpColl.Length; i++)
        {
            if (tmpColl[i].tag != "dir")
            {
                for(int j=0; j<9; j++)
                {
                    if(rotCubes[j] == null)
                    {
                        rotCubes[j] = tmpColl[i].transform.gameObject;
                        break;
                    }
                }
            }
        }
        rotFlag = true;
    }

}
