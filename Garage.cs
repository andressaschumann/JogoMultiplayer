using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking ;

public class Garage : NetworkBehaviour  {
	 public Transform spawnCar;
	public GameObject carPrefab;
	 float timeDestroy;
	 float timeSpawn;
	 int  randomNum;
	public Transform  playerL; 



	void Start () {
	}
		
	[Command]
	void CmdSpawnCar(){ 
		GameObject car = Instantiate (carPrefab, spawnCar.position, Quaternion.identity );
		NetworkServer.Spawn (car);
		car.GetComponent <Car>().owner = playerL;

	}
	void Update () {
		
		timeDestroy += Time.deltaTime;
		timeSpawn += Time.deltaTime;
		if (timeSpawn > 3) {
			CmdSpawnCar ();
			timeSpawn = 0;			
		}
	}
		

}
