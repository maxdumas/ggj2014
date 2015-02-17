using UnityEngine;
using System.Collections;
	
public class loadLevel : MonoBehaviour {
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2 - 45, Screen.height/2 + 20, 75, 30), "PLAY!"))
		Application.LoadLevel("main");
	}
}