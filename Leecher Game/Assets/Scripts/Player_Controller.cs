/*using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {


    public static CharacterController CharacterController;
    public static Player_Controller instance;
	

    
    void Awake() {

        CharacterController = GetComponent("CharacterController") as CharacterController;
        instance = this;
		Player_Camera.UseExistingOrCreateNewMainCamera();
	
	}
	
	
	void Update() {

        if (Camera.mainCamera == null){
            return;
        }
        

        GetLocomotionInput();
		HandleActionInput();
		
		
		Player_Movement.instance.UpdateMotor();
	
	}

    void GetLocomotionInput(){
		
		var deadZone = 0.1f;
		Player_Movement.instance.verticalVelo = Player_Movement.instance.moveVector.y;
		Player_Movement.instance.moveVector = Vector3.zero;
		
		if(Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone){
			Player_Movement.instance.moveVector += new Vector3(0,0, Input.GetAxis("Vertical"));
		}
		if(Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone){
			Player_Movement.instance.moveVector += new Vector3(Input.GetAxis("Horizontal"),0,0);
		}

	}
	
	void HandleActionInput(){
		
		if(Input.GetButton("Jump")){
			
			Jump();
		}
	}
	void Jump(){
	
		Player_Movement.instance.Jump();
	}

}
 */