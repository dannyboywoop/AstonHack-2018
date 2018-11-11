using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {

    private GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawn");
        Invoke("spawnEnemies", 2);
	}
	
	void spawnEnemies()
    {
        foreach (GameObject sp in spawnPoints)
        {
            sp.GetComponent<enemySpawner>().spawnEnemy();
        }
        Invoke("spawnEnemies", 10);
    }
}
