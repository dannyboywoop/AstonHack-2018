using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour {

    public Camera camera;

    private Vector3 LastCameraPosition;
    private Vector3 LastToughHit;

    public Vector3 GetLatestCameraPosition() {
        return LastCameraPosition;
    }

    public Vector3 GetLatestTouchHit() {
        return LastToughHit;
    }

    void Update () {
        LastCameraPosition = camera.transform.position;
        Touch touch = Input.GetTouch(0);

        TrackableHit hit;
        if(Frame.Raycast(new Vector3(touch.position.x, 0f, touch.position.y), camera.transform.forward, out hit)) {
            LastToughHit = hit.Pose.position;
        }

        if (Input.touchCount >= 1) {
           //TODO
        }
    }
}
