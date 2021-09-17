using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : PortalTraveller {
    public float maxSpeed = 1;
    float speed;
    float targetSpeed;
    float smoothV;

    void Start () {
        Debug.Log ("Press F to start/stop car");
        targetSpeed = maxSpeed;
    }

    void Update () {
        // Use deltatTime to account for variable framerate
        float moveDst = Time.deltaTime * speed;
        transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKeyDown (KeyCode.F)) {
            targetSpeed = (targetSpeed == 0) ? maxSpeed : 0;
        }

        // Ramp the speed of the Car down slowly
        speed = Mathf.SmoothDamp (speed, targetSpeed, ref smoothV, .5f);
    }
}
