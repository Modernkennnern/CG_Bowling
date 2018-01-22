using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBoost : MonoBehaviour {
    public float BoostPower = 10;

    void OnTriggerEnter(Collider collider) {
        var body = collider.GetComponent<Rigidbody>();
        if (body != null) {
            body.velocity *= BoostPower;
        }
    }
}