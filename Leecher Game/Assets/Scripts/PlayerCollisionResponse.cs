using UnityEngine;
using System.Collections;

public class PlayerCollisionResponse : MonoBehaviour {

	void OnTriggerEnter(Collider collisonInfo){
		
		if(collisonInfo.gameObject.tag == "lava"){
			Destroy(collisonInfo.gameObject);
		Application.LoadLevel("Game Over");
		}
	}
}
