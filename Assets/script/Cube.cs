﻿using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public Vector3 Pos;

	// Use this for initialization
	void Start () {
        transform.tag = GetComponent<MeshRenderer>().materials[0].name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
