using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	
	 public Transform firstSpawnPoint;
	 public Transform secondSpawnPoint;
	
	
	void Update () {

		if(MoveAround.firstRespawn == true){
			
			transform.position = firstSpawnPoint.position;
			
			MoveAround.firstRespawn =false;
		}
		else if(MoveAround.secondRespawn == true){
			
			transform.position = secondSpawnPoint.position;
			MoveAround.secondRespawn =false;
		}
	}
}
