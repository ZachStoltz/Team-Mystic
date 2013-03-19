/*using UnityEngine;
using System.Collections;

public class Player_Camera : MonoBehaviour {

	
	public static Player_Camera instance;
	
	public Transform targetToLookAt;
	
	public float distance = 5f;
	public float distanceMin = 3f;
	public float distanceMax = 10f;
	public float distanceSmooth = 0.05f;
	
	public float x_mouseSensitivity = 5f;
	public float y_mouseSensitivity = 5f;
	public float mouseWheelSensitivity = 5f;
	public float x_Smooth = 0.05f;
	public float y_Smooth = 0.01f;
	public float z_Smooth = 0.05f;
	public float y_MinLimit = -40f;
	public float y_MaxLimit = 80f;
	
	private float mouseX = 0f;
	private float mouseY = 0f;
	private float velX = 0f;
	private float velY = 0f;
	private float velZ = 0f;
	private float velDistance = 0f;
	private float startDistance = 0f;
	private Vector3 position;
	private Vector3 desiredPosition = Vector3.zero;
	private float desiredDistance = 0f;
	
	void Awake(){
	
		instance = this;
	}
	
	void Start() {
	
		distance = Mathf.Clamp(distance,distanceMin,distanceMax);
		startDistance = distance;
		Reset();
	}
	
	
	void LateUpdate() {
		
		if(targetToLookAt == null)
		return;
		
		HandleInput();
		CalculateDesiredPosition();
		UpdatePosition();
	}
	
	void HandleInput(){
		
		var deadArea = 0.01f;
		
		if(Input.GetMouseButton(1)){
		
			mouseX += Input.GetAxis("Mouse X") * x_mouseSensitivity;
			mouseY -= Input.GetAxis("Mouse Y") * y_mouseSensitivity;
		}
		// limit the movement of mouseY
		mouseY = Helper.ClampAngle(mouseY, y_MinLimit, y_MaxLimit);
		
		if(Input.GetAxis("Mouse ScrollWheel") < -deadArea || Input.GetAxis("Mouse ScrollWheel") > deadArea){
		
			desiredDistance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * mouseWheelSensitivity, distanceMin, distanceMax);
		}
	}
	
	void CalculateDesiredPosition(){
		
		distance = Mathf.SmoothDamp(distance, desiredDistance, ref velDistance, distanceSmooth);
		
		desiredPosition = CalculatePosition(mouseY,mouseX,distance);
	}
	Vector3 CalculatePosition(float rotationX, float rotationY, float distance){
		
		Vector3 direction = new Vector3(0,0, -distance);
		Quaternion rotation = Quaternion.Euler(rotationX,rotationY,0);
		
		return targetToLookAt.position + rotation * direction;
	}
	float CheckCameraPoints(Vector3 from, Vector3 to){
		
		
	}
	
	void UpdatePosition(){
		
		var posX = Mathf.SmoothDamp(position.x,desiredPosition.x, ref velX, x_Smooth);
		var posY = Mathf.SmoothDamp(position.y,desiredPosition.y, ref velX, y_Smooth);
		var posZ = Mathf.SmoothDamp(position.z,desiredPosition.z, ref velX, z_Smooth);
		
		position = new Vector3(posX,posY,posZ);
		transform.position = position;
		transform.LookAt(targetToLookAt);
	}
	
	public void Reset(){
		
		mouseX = 0;
		mouseY = 10;
		distance = startDistance;
		desiredDistance = distance;
	}
	public static void UseExistingOrCreateNewMainCamera(){
	
		GameObject tempCamera;
		GameObject targetToLookAt;
		Player_Camera myCamera;
		
		if(Camera.mainCamera != null){
		
			tempCamera = Camera.mainCamera.gameObject;
		}
		else{
			tempCamera = new GameObject("Main Camera");
			tempCamera.AddComponent("Camera");
			tempCamera.tag = "MainCamera";
		}
		
		tempCamera.AddComponent("Player_Camera");
		myCamera = tempCamera.GetComponent("Player_Camera") as Player_Camera;
		
		targetToLookAt = GameObject.Find("targetToLookAt") as GameObject;
		
		if(targetToLookAt == null){
		
			targetToLookAt = new GameObject("targetToLookAt");
			targetToLookAt.transform.position = Vector3.zero;
		}
		
		myCamera.targetToLookAt = targetToLookAt.transform;
	}
}
*/