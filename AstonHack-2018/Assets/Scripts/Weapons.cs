using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

	public GameObject Boulder;

	public Camera FirstPersonCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnBoulder() {
		GameObject boulder = Instantiate(Boulder, FirstPersonCamera.transform.position, Quaternion.identity, transform);
	}
}
