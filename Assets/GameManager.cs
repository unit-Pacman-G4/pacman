using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	static int score = 0;
	static bool gameOver;
	public GUISkin labelSkin;
	public GUISkin labalSmall;

	public static void updateScore(){
		score++;
	}
	public static void gameOverSet(){
		gameOver = true;
	}
	void OnGUI(){
		GUI.skin = labelSkin;
		GUI.Label (new Rect (10, 20, 100, 100), "" + score);
		if (gameOver) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2-85, 400, 100), "Game Over!");
			GUI.skin = labalSmall;
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2-35, 400, 100), "Press R to restart!");
			if(Input.GetKey("r")) {
				score = 0;
				gameOver = false;
				Application.LoadLevel(1);
			}
		}
	}
}
