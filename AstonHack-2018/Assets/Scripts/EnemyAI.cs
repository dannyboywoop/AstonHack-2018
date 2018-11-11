using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public Transform goal;
    public GameObject GameOverText;

	// Use this for initialization
	void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
    }

    private void Update() {
        if((transform.position - goal.position).magnitude < 2.0f) {
            GameOverText.SetActive(true);
            Destroy(transform.gameObject);
        }
    }

}
