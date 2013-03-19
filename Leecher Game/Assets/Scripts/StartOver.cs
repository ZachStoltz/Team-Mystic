using UnityEngine;
using System.Collections;

public class StartOver : MonoBehaviour {
	
	public int xPos = Screen.width /2;
	public int yPos = Screen.height /2;
	void OnGUI(){
		
	if(GUI.Button(new Rect(xPos , yPos, 300, 150), "Start Over")){
		
			Application.LoadLevel("Main Menu");
		}
	}
}
