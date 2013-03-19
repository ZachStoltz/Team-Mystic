using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

	public int xPos = Screen.width /2;
	public int yPos = Screen.height /2;
	void OnGUI(){
		
	if(GUI.Button(new Rect(xPos , yPos, 300, 150), "VICTORYYYYYY")){
		
			Application.LoadLevel("Main Menu");
		}
	}
}
