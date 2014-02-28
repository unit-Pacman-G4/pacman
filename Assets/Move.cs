using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	int speed = 5;

	// Use this for initialization
	void Start () {
		Vector2 pos = rigidbody2D.velocity;
		pos.x = speed * -1;
		rigidbody2D.velocity = pos;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 pos = rigidbody2D.velocity;
		if (Input.GetAxis ("Horizontal") > 0) {
			//pos.y = 0;
			pos.x = speed;
		}
		else if (Input.GetAxis ("Horizontal") < 0) {
			//pos.y = 0;
			pos.x = speed * -1;
		}
		if (Input.GetAxis ("Vertical") > 0) {
			//pos.x = 0;
			pos.y = speed;
		}
		else if (Input.GetAxis ("Vertical") < 0) {
			//pos.x = 0;
			pos.y = speed * -1;
		} 
		rigidbody2D.velocity = pos;
	
	}

	void OnTriggerEnter2D(Collider2D other)
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
		else if (other.gameObject.name == "oneWayDoor") {

			rigidbody2D.velocity = Vector2.zero;
			Vector2 pos = rigidbody2D.velocity;
			Debug.Log(pos.y + ":y   x: " + pos.x);
			pos.y = 9000;
			rigidbody2D.velocity = pos;
			pos = rigidbody2D.velocity;
			Debug.Log(pos.y + ":y   x: " + pos.x);
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "npc") {
			if(GameManager.pcpStatus()){
				Destroy(other.gameObject);
			}
			else{
				if(Singleton.instance.Health > 0){ 
					Singleton.instance.Health -=1;
					string healthbarToKill = "health" + (3-Singleton.instance.Health);
					Destroy(GameObject.Find(healthbarToKill).gameObject);
					Vector3 pos = transform.position;
					pos.y = -2.675865f;
					pos.x = 0.006740279f;
					transform.position = pos;
				
				}
				else {
					GameManager.gameOverSet();
					Destroy(this.gameObject);
				}
			}

		}
		//Debug.Log(other.relativeVelocity.magnitude);
	}
}
