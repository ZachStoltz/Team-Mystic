using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	void OnGUI () {
		
		if(GUI.Button(new Rect(Screen.width / 2, Screen.height /2, 100, 100),"Play Game")){
		
			Application.LoadLevel("Level One");
		}	
	}
}
