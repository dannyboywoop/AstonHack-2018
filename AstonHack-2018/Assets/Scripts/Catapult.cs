using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {

    public GameObject ProjectilePrefab;
    public Camera FirstPersonCamera;

    private Vector3 CatapultStartPosition;
    private Vector3 CatapultReleasePosition;

    private bool DrawingBack = false;

    public void OnCatapultButton() {
        if (!DrawingBack) {
            SetStartPosition();
            DrawingBack = !DrawingBack;
        } else if (DrawingBack) {
            SetReleasePosition();
            ReleaseProjectile();
            DrawingBack = !DrawingBack;
        }
    }

	private void SetStartPosition() {
        CatapultStartPosition = FirstPersonCamera.transform.position;
    }

    private void SetReleasePosition() {
        CatapultReleasePosition = FirstPersonCamera.transform.position;
    }

    private void ReleaseProjectile() {
        GameObject FiredProjectile = Instantiate(ProjectilePrefab, FirstPersonCamera.transform.position, Quaternion.identity, transform);
        FiredProjectile.GetComponent<Rigidbody>().AddForce((CatapultStartPosition - CatapultReleasePosition).normalized * 100f, ForceMode.Impulse);
    }
}
