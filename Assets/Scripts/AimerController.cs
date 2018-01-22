using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerController : MonoBehaviour {

    public Transform ball;
    public GameObject cylinder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(ball);
    }
    public void SetAimColor(Color color) {
        cylinder.GetComponent<MeshRenderer>().material.color = color;
    }
}
