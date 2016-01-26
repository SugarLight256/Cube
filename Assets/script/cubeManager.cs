using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubeManager : MonoBehaviour {

    public static int boxSize;

    private int cubeCount;
    private int deg = 0;
    private int rotDeg;
    private int solvePhase=0;

    private bool rotFlag;
    public static bool autoSolve; 

    private Vector3 axis;
    private Vector3 point;

    public List<GameObject> cubes;
    public GameObject[] rotCubes = new GameObject[9];

    public int[,,] panelColor = new int[6, 3, 3];
    private Ray[,,] rays = new Ray[6, 3, 3];

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
        cubes = new List<GameObject>();
	    for(int i=0; i<boxSize; i++)
        {
            for (int j = 0; j < boxSize * boxSize; j++)
            {
                cubes.Add(transform.GetChild(i*boxSize*boxSize+j).gameObject);
            }
        }

        float[] xyz = new float[3];
        for(int i=0; i<6; i++)
        {
            if (i < 3)
            {
                xyz[i % 3] = 4;
            }
            else
            {
                xyz[i % 3] = -4;
            }
            for(int x=0; x<3; x++)
            {
                xyz[(i+1)%3] = x + 0.5f;
                for(int y=0; y<3; y++)
                {
                    xyz[(i+2)%3] = y + 0.5f;
                    rays[i, x, y] = new Ray(new Vector3(xyz[0], xyz[1], xyz[2]), new Vector3((int)(-xyz[0] / 4), (int)(-xyz[1] / 4), (int)(-xyz[2] / 4)));
                    //Debug.Log(rays[i, x, y]);
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        if(!rotFlag && (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.D)))
        {
            keyToDir(Input.inputString[0], false, 90);
        }
        if (rotFlag && deg < rotDeg*9)
        {
            for (int i = 0; i < 9; i++)
            {
                rotCubes[i].transform.RotateAround(point, axis, 5.0f);
                deg+=5;
            }
        }
        else
        {
            rotFlag = false;
            rotCubes = null;
            deg = 0;
        }
        setPanelColor();
    }

    private void setPanelColor()
    {
        RaycastHit hit;
        for(int i=0; i<6; i++)
        {
            for(int j=0; j<3; j++)
            {
                for(int k=0; k<3; k++)
                {
                    Physics.Raycast(rays[i,j,k],out hit);
                    switch (hit.transform.tag)
                    {
                        case "white":
                            panelColor[i, j, k] = 0;
                            break;
                        case "yellow":
                            panelColor[i, j, k] = 1;
                            break;
                        case "blue":
                            panelColor[i, j, k] = 2;
                            break;
                        case "red":
                            panelColor[i, j, k] = 3;
                            break;
                        case "green":
                            panelColor[i, j, k] = 4;
                            break;
                        case "orange":
                            panelColor[i, j, k] = 5;
                            break;
                        default:
                            panelColor[i, j, k] = -1;
                            break;
                    }
                }
            }
        }
    }

    private void keyToDir(char key, bool Reverse, int setDeg) {
        int[] tmpColor = { 0, 0, 0 };
        switch (key)
        {
            case 'R':
                axis = new Vector3(1, 0, 0);
                Rotation(Right);
                break;
            case 'L':
                axis = new Vector3(-1, 0, 0);
                Rotation(Left);
                break;
            case 'F':
                axis = new Vector3(0, 0, -1);
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
                axis = new Vector3(0, -1, 0);
                Rotation(Down);
                break;
        }
        if (Reverse)
        {
            axis *= -1;
        }
        rotDeg = setDeg;
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

    private void solving()
    {
        switch (solvePhase)
        {
            case 0://D_cross
                D_cross();
                break;
            case 1://F2L
                F2L();
                break;
            case 2://OLL
                OLL();
                break;
            case 3://PLL
                PLL();
                break;
        }
    }

    private void D_cross()
    {

    }

    private void F2L()
    {

    }

    private void OLL()
    {

    }

    private void PLL()
    {

    }

}
