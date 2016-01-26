using UnityEngine;
using System.Collections;

public class tagSetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string tmp = GetComponent<MeshRenderer>().materials[0].name;
        tag = tmp.Split(' ')[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
