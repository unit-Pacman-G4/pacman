using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public GUISkin gameOverStyle;

	void OnGUI(){
		GUI.skin = gameOverStyle;
		GUI.skin.label.fontSize = 83;
		GUI.Label (new Rect (Screen.width/2-300, 200, 600, 200), "Game Over!");
		GUI.skin.label.fontSize = 50;
		GUI.Label (new Rect (Screen.width/2-300, 300, 600, 200), "Press R to Restart");

	}
	void Update(){
		if (Input.GetKeyDown ("r"))
			Application.LoadLevel (0);
	}
}
