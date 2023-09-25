using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Input.mousePosition;
    }
}
