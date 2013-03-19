/*using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public static Player_Movement instance;
	public float moveSpeed = 10f;
	public float gravity = 21f;
	public Vector3 moveVector { get; set; }
	private float jumpSpeed = 9.0f;
	public float verticalVelo {get; set;}
	public float termVelo = 20f;
	
	void Awake(){
	
		instance = this;
	}
	
	public void UpdateMotor(){
		
		SnapAlignCharacterWithCamera();
		ProcessMotion();
	}
	
	void ProcessMotion(){
		
		//Making moveVector to World Space
		moveVector = transform.TransformDirection(moveVector);
		
		// making sure to normalize moveVector if Magn > 1
		
		if(moveVector.magnitude >1)
			moveVector = Vector3.Normalize(moveVector);
		// moveVector * moveSpeed
		moveVector *= moveSpeed;
		
		//Reapply VertVelo to moveVector.y
		moveVector = new Vector3(moveVector.x, verticalVelo ,moveVector.z);
		
		//apply gravity
		ApplyGravity();
		
		// Move Character relative to World Space
		Player_Controller.CharacterController.Move(moveVector * Time.deltaTime);
	}
	
	void SnapAlignCharacterWithCamera(){
		
		if(moveVector.x != 0 || moveVector.z != 0){
		
			transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
												  Camera.mainCamera.transform.eulerAngles.y, 
												  transform.eulerAngles.z);
		}
	}
	void ApplyGravity(){
	
		if(moveVector.y > - termVelo){
		
		moveVector = new Vector3(moveVector.x, moveVector.y - gravity * Time.deltaTime,moveVector.z);
		}
		if(Player_Controller.CharacterController.isGrounded && moveVector.y < -1){
			moveVector = new Vector3(moveVector.x, -1 ,moveVector.z);
		}
		
	}
	public void Jump(){
		
		if(Player_Controller.CharacterController.isGrounded){
		
			verticalVelo = jumpSpeed;
		}
	}
}
*/