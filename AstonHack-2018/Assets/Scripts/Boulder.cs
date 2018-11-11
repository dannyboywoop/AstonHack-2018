using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	public int damageValue = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "enemy")
        {
            col.gameObject.GetComponent<Health>().damage(damageValue);
        }
    }
	
}
