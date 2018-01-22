using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameController gameController;

    // One of these are not being used.
    public float distanceUp; // y
    public float distanceBehind; // z

	// Use this for initialization
	void Start () {
        var position = this.transform.GetChild(0).transform.position;
        position.y += distanceUp;
        position.z -= distanceBehind;
        this.transform.GetChild(0).transform.position = position;

    }
	
	// Update is called once per frame
	void Update () {
        var position = gameController.ball.transform.position;

        this.transform.position = position;
        this.transform.GetChild(0).LookAt(gameController.ball.transform.position);


        if (Input.GetMouseButton(1)) {
            // Free look

            Cursor.lockState = CursorLockMode.Locked;
            var horizontal = Input.GetAxis("Mouse X");
            var rotation = this.transform.eulerAngles;
            rotation.y += horizontal;
            this.transform.eulerAngles = rotation;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
