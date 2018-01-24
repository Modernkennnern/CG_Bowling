using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject pins;
    public BallController ball;
    public float chargeSeconds = 5;

    private float pressedTime;

    private void Start() {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            var ballSpawner = GameObject.Find("ballSpawner");
                ballSpawner.GetComponent<ObjectSpawner>().SpawnObjects();
            var pinSpawner = GameObject.Find("pinSpawner");
                pinSpawner.GetComponent<ObjectSpawner>().SpawnObjects();
            Debug.Log(pinSpawner);
            Debug.Log(ballSpawner);
        }

        // når vi presser mus så starter vi en timer
        if (!ball.IsMoving) { 
            if (Input.GetMouseButtonDown(0)) {
                pressedTime = Time.time;
            }
            if (Input.GetMouseButton(0) && pressedTime > 0) {
                var color = Color.Lerp(Color.yellow, Color.red, (Time.time - pressedTime) / chargeSeconds);
                ball.aimer.SetAimColor(color);
            }
            if (Input.GetMouseButtonUp(0)) {
                ball.aimer.SetAimColor(Color.yellow);
                float power = (Time.time - pressedTime) / chargeSeconds;
                if (power > 1) {
                    Debug.Log("Adrian!!");
                }
                else {
                    ball.Throw(power);
                }
                pressedTime = -1; // acts as a flag for color morph
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
                ball.Jump();
        }
        if (Input.GetKeyDown(KeyCode.T)) ball.Throw(1); //DEBUG CODE
            // tiden mellom X sekunder bestemmer fargen mellom gul og rød
        }
}