using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking ;

public class Car : NetworkBehaviour  {
	 NavMeshAgent agent;
	public  Transform owner;


	void Start () {
		
		agent = GetComponent<NavMeshAgent > ();
		StartCoroutine (CarDestroy());

	}
		
	void Update () {
		if (isServer) {
			agent.destination = owner.position;
		}
	}

	IEnumerator CarDestroy ()
	{
		yield return new WaitForSeconds (Random.Range(3,10));
		NetworkServer.Destroy (this.gameObject);
	}


}
