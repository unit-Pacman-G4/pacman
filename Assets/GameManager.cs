using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {
	static int score = 0;
	static bool gameOver;
	public GUISkin labelSkin;
	public GUISkin labalSmall;

	public static bool pcpOn;
	public static double pcpTime = -0.0;
	float wait = 2.0f;

	public static void updateScore(){
		score++;
	}
	public static void gameOverSet(){
		gameOver = true;
	}
	public static void setPCP(){
		pcpOn = true;
		pcpTime = 10.0;
	}
	public static bool pcpStatus(){
		if (pcpOn != false && pcpTime < 0) {
			pcpOn = false;
		} 
		return pcpOn;
	}
	void Start(){
	}
	void Update(){
		if (pcpTime > 0) {
			pcpTime -= Time.deltaTime;
			Debug.Log ("pcpTime: " + pcpTime);
				}

		GameObject coin = GameObject.Find ("coin");
		if (coin == null) {
			wait -= Time.deltaTime;
			score = 0;
			if(wait < 0){
				wait = 2.0f;
				Application.LoadLevel (Application.loadedLevel+1);
			}
		}
						
	}

	void OnGUI(){
				GUI.skin = labelSkin;
				GUI.Label (new Rect (Screen.width / 2 - 40, 0, 250, 200), "Score: " + score);
				GUI.Label (new Rect (Screen.width / 2 + 400, 0, 250, 200), "Health: " + Singleton.instance.Health);
				if (wait != 2.0f)
						GUI.Label (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 85, 400, 100), "Level Complete!");
				if (gameOver) {
						score = 0;
						gameOver = false;
						Destroy(this.gameObject);
						Application.LoadLevel (4);
				}

		}

}
