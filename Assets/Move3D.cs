using UnityEngine;
using System.Collections;

public class Move3D : MonoBehaviour {
	int speed = 5;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") > 0) {

			transform.Rotate(Vector3.up, Time.deltaTime*100);

		}
		else if (Input.GetAxis ("Horizontal") < 0) {

			transform.Rotate(Vector3.down, Time.deltaTime*100);
		}
		if (Input.GetAxis ("Vertical") > 0) {

			transform.Translate(Vector3.forward * Time.deltaTime*3);

		}
		else if (Input.GetAxis ("Vertical") < 0) {

			transform.Translate(Vector3.back * Time.deltaTime*3);
		} 

		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "coin") {
			Destroy(other.gameObject);
			GameManager.updateScore();
		}
		else if (other.gameObject.name == "pcp") {
			Destroy(other.gameObject);
			GameManager.setPCP();
		}
		else if (other.gameObject.name == "leftPort") {
			Vector3 pos = transform.position;
			pos.x *= -1;
			transform.position = pos;
		}
		else if (other.gameObject.name == "rightPort") {
			Vector3 pos = transform.position;
			pos.x *= -1;
			transform.position = pos;
		}

	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "npc") {
			if(GameManager.pcpStatus()){
				Destroy(other.gameObject);
			}
			else{
				GameManager.gameOverSet();
				Destroy(this.gameObject);
			}
			
		}
	}
}
