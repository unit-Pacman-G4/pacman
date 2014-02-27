using UnityEngine;
using System.Collections;

public class CamMove3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find ("player");
		transform.position = player.transform.position;

	
	}
}
