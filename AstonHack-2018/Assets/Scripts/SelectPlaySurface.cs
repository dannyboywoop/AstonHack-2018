using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlaySurface : MonoBehaviour {

    public Camera FirstPersonCamera;

    public GameObject DetectedPlanePrefab;

    public GameObject SearchingForPlaneUI;

    public GameObject PlaneGeneratorObject;

    public GameObject ConfirmationPanel;

    public GameObject GameMap;

    public GameObject PointCloudObject;

    private List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();

    private bool ContinueSearching = true;

    private Anchor SelectedPlaneAnchor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!ContinueSearching) {
            return;
        }

        Session.GetTrackables<DetectedPlane>(m_AllPlanes);
        bool showSearchingUI = true;
        for (int i = 0; i < m_AllPlanes.Count; i++) {
            if (m_AllPlanes[i].TrackingState == TrackingState.Tracking) {
                showSearchingUI = false;
                break;
            }
        }

        SearchingForPlaneUI.SetActive(showSearchingUI);

        Touch touch;
        if (Input.touchCount < 1 || ( touch = Input.GetTouch(0) ).phase != TouchPhase.Began) {
            return;
        }

        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit)) {
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            ConfirmationPanel.SetActive(false);
            if (( hit.Trackable is DetectedPlane ) &&
                Vector3.Dot(FirstPersonCamera.transform.position - (hit.Pose.position*100),
                    hit.Pose.rotation * Vector3.up) < 0) {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else {
                SelectedPlaneAnchor = hit.Trackable.CreateAnchor(hit.Pose);
                SelectedPlaneAnchor.transform.position = new Vector3(SelectedPlaneAnchor.transform.position.x * 100, 0f, SelectedPlaneAnchor.transform.position.y * 100);
                ConfirmationPanel.SetActive(true);
            }
        }
    }

    public void SurfaceSelected() {
        GameObject newGameMap = Instantiate(GameMap, SelectedPlaneAnchor.transform.position - new Vector3(0.5f, 0f, 0.5f), Quaternion.identity, transform);
        newGameMap.transform.parent = SelectedPlaneAnchor.transform;

        ContinueSearching = false;
        ConfirmationPanel.SetActive(false);
        PlaneGeneratorObject.SetActive(false);
        PointCloudObject.SetActive(false);
    }
}
