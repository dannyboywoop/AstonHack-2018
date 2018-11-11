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
        /*
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
        */
    }

    public void SurfaceSelected() {
        GameObject newGameMap = Instantiate(GameMap, FirstPersonCamera.transform.position - (new Vector3(50f,0f,50f)), Quaternion.identity, transform);

        ContinueSearching = false;
        ConfirmationPanel.SetActive(false);
        PlaneGeneratorObject.SetActive(false);
        PointCloudObject.SetActive(false);
    }
}
