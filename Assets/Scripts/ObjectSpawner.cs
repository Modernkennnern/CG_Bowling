using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public string objectName;
    public GameObject preFab;

    // Use this for initialization
    void Start() {
        SpawnObjects();
    }
    void Update() {

    }

    public void SpawnObjects() {
        var spawnedObject = GameObject.Find(objectName);
        if (spawnedObject == null) {
            spawnedObject = Instantiate(preFab, transform.position, Quaternion.identity);
            spawnedObject.transform.rotation = this.transform.rotation;
        }
        else {
            spawnedObject.transform.position = this.transform.position;
        }
        var gc = GameObject.FindObjectOfType<GameController>();
        var ball = spawnedObject.GetComponent<BallController>();
        if (ball != null) {
            gc.ball = ball;
        }
        this.gameObject.SetActive(false);
    }
}


