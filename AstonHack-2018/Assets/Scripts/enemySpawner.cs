using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject enemyPreFab;
    public GameObject goal;

    void Start()
    {
        this.tag = "spawn";  
    }

    // Use this for initialization
    public void spawnEnemy() {
        GameObject agent = Instantiate(enemyPreFab, this.transform.position, Quaternion.identity);
        agent.GetComponent<EnemyAI>().goal = goal.transform;
	}
	
}
