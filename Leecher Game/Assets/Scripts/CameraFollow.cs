using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform targetToFollow;
	public float camDistance = 5.3f;
	public float camHeight = 2.5f;
	
	private float positionDamping = 10000.0f;
	private float rotationDamping = 10000.0f;
	

	

	




	
	void LateUpdate(){
	
	
		if(!targetToFollow){
		return;
		}
		
		Vector3 wantedPosition = targetToFollow.position + targetToFollow.up * camHeight - targetToFollow.forward * camDistance; 
	
        Quaternion wantedRotation = Quaternion.LookRotation(targetToFollow.position-transform.position, targetToFollow.up); 
        
		transform.position = Vector3.MoveTowards(transform.position, wantedPosition, positionDamping * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, rotationDamping * Time.deltaTime);
		
	
	}

}