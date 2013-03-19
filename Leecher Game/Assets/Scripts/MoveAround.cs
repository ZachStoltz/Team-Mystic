using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class MoveAround : MonoBehaviour {
	
	
	private float moveSpeed = 8.0f;
	private float rotateSpeed = 2.0f;
	private float jumpSpeed = 9.0f;
	
	private bool isIdle = false;
	private bool isRunningForward = false;
	private bool isRunningBackward = false;
	private float gravity = 20.0f;
	private Vector3 forward = Vector3.zero;
	private float curSpeed;
	public float slideThreshold = 0.6f;
	public float maxSlideMagnitude = 0.6f;
	
	public Camera mainCamera;
	public Camera slideCamera;
	public Camera lastCamera;
	
	private Vector3 slideDirec;
	
	public static bool firstRespawn = false;
	public static bool secondRespawn = false;
	public static bool dead = false;
	
	public GUIText playerHealth;
	public int lifeRemaining;
	
	void Awake(){
		mainCamera.enabled = true;
		slideCamera.enabled = false;
		lastCamera.enabled = false;
		playerHealth.material.color = Color.black;
		lifeRemaining = 3;
	
	}
	void OnTriggerEnter(Collider collisonInfo){
		
		if(collisonInfo.gameObject.tag == "lava"){
		lifeRemaining -= 1;
			Debug.Log(lifeRemaining);
		firstRespawn = true;
		}
		
		if(collisonInfo.gameObject.tag == "ice"){

			mainCamera.enabled = false;
			slideCamera.enabled = true;	
			lastCamera.enabled = false;
		}
		if(collisonInfo.gameObject.tag == "switchBackCam"){
		
			mainCamera.enabled = true;
			slideCamera.enabled = false;
			lastCamera.enabled = false;
		}
		if(collisonInfo.gameObject.tag == "Finish"){
		
			mainCamera.enabled = false;
			slideCamera.enabled = false;
			lastCamera.enabled = true;
		}
		if(collisonInfo.gameObject.tag == "firstRespawn"){
		lifeRemaining -= 1;	
			firstRespawn = true;
		}
		if(collisonInfo.gameObject.tag == "secondRespawn"){
		lifeRemaining -= 1 ;
			secondRespawn = true;
		}
		if(collisonInfo.gameObject.tag == "Win"){
		
			Application.LoadLevel("Victory");
		}
	}
	

	
	void Update (){
	
		CharacterController controller = GetComponent<CharacterController>();
		transform.Rotate(0,Input.GetAxis("Horizontal")* rotateSpeed,0);
		if(controller.isGrounded){
			
			forward = new Vector3(0,0,Input.GetAxis("Vertical"));
			
			forward = transform.TransformDirection(forward);
			forward *= moveSpeed;
			
			if(Input.GetButtonDown("Jump")){
				
				forward.y = jumpSpeed;
				animation.Play("jump_pose");
			}	
		slideDirec = Vector3.zero;
		
		RaycastHit hitInfo;
		
		if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hitInfo)){
			
				if(hitInfo.normal.y < slideThreshold){
				
				slideDirec = new Vector3(hitInfo.normal.x, -hitInfo.normal.y, hitInfo.normal.z);
				}
			}
		if(slideDirec.magnitude < maxSlideMagnitude){
			forward += slideDirec;
			}
		else{
				forward = slideDirec * 17;	
			}
		}
		
		forward.y -= gravity * Time.deltaTime;
		controller.Move(forward * Time.deltaTime);
		
			if(Input.GetAxis("Vertical") > 0){
				isRunningForward = true;
				if(isRunningForward == true){
					
				animation.Play("run_forward");
				}
			}
			else if(Input.GetAxis("Vertical") < 0){
				isRunningBackward = true;
				if(isRunningBackward == true){
				animation.Play("run_backward");
				}
			}
			else{
				animation.Play("idle");
		}
		AdjustHealth(lifeRemaining);
	}
	
	 void AdjustHealth(int lifeRemaining){
			switch(lifeRemaining){

		case 3:
			playerHealth.text = "Life: "+ lifeRemaining + "/3";
			
			break;
		case 2:
			playerHealth.text = "Life: "+ lifeRemaining + "/3";
			
			break;
		case 1:
			playerHealth.text = "Life: "+ lifeRemaining + "/3";
			playerHealth.material.color = Color.red;
			
			break;
		case 0:
			playerHealth.text = "Life: "+ lifeRemaining + "/3";
			
			break;
		}
		if(lifeRemaining <= 0){
			lifeRemaining = 0;
			Application.LoadLevel("Game Over");
		}
	}
}

