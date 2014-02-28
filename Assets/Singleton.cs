using System;
using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	private static Singleton _instance;
	
	void Awake(){
		Debug.Log("EnSingleton Awake");
		if(_instance != null && _instance != this){
			Debug.Log("EnSingleton Destructing ");
			Destroy(this.gameObject);
			return;
		}
		_instance = this;
		DontDestroyOnLoad(this.gameObject);
		
		
		var c = GetComponents<MonoBehaviour>();
	}
	
	
	void Update () {
		//Debug.Log (helse);
		
	}
	
	
	public static Singleton instance{ get{return _instance;} }
	
	
	private int health = 3;
	
	
	public int Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}
	
	
	
}