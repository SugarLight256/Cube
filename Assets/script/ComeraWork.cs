using UnityEngine;
using System.Collections;

public class ComeraWork : MonoBehaviour {

    public int time = 20;
    public string PathName;

    public GameObject target;

	// Use this for initialization
	void Start () {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath(PathName), "time", time, "loopType", "loop", "easeType", iTween.EaseType.linear));
        
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.LookAt(target.transform);
	}
}
