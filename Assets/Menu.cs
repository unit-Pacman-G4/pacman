using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width / 2-50, Screen.height/2+150, 100, 40), "Start Game")) {
			Application.LoadLevel(1);		
		}
		if (GUI.Button (new Rect (Screen.width / 2-50, Screen.height/2+190, 100, 40), "Exit")) {
			Application.Quit();		
		}
	}
}
