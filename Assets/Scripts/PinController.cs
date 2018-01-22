using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour {

    [System.Serializable]
    public class StartVariables {
        public Vector3 startPosition, startRotation;
    }

    public StartVariables startVariables = new StartVariables();

	// Use this for initialization
	void Start () {
        startVariables.startPosition = transform.position;
        startVariables.startRotation = transform.eulerAngles;

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -10) {
            DestroyObject(this.gameObject);
        }
        Vector3 currentRotation = transform.eulerAngles;

        if ( (Mathf.Abs(Mathf.DeltaAngle(currentRotation.x, startVariables.startRotation.x)) > 30) || (Mathf.Abs(Mathf.DeltaAngle(currentRotation.z, startVariables.startRotation.z) ) > 30) || (Mathf.Abs(Mathf.DeltaAngle(currentRotation.y, startVariables.startRotation.y) ) > 30) ) {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
	}
}
