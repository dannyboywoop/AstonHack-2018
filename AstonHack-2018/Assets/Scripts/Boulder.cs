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
		if(GetComponent<Rigidbody>().velocity == Vector3.zero) {
            Invoke("DespawnBoulder", 3);
        }
        if(transform.position.y < -10) {
            DespawnBoulder();
        }
	}

	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
            //col.gameObject.GetComponent<Health>().damage(damageValue);
        }
    }

    void DespawnBoulder() {
        Destroy(transform.gameObject);
    }
	
}
