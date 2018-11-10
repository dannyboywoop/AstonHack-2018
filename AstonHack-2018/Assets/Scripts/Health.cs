using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth = 100;

	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Debug.Log("Died!");
			// Play death animation
			// ToDo

			// Destroy Game object
			Destroy(transform.parent.gameObject);
		}
	}

	public void damage(int damageValue) {
		Debug.Log("Taking damage");
		currentHealth -= damageValue;
	}
}
