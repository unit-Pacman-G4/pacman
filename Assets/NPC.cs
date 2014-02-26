using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	int speed = 150;
	int dir = 3;
	bool changeDir = true;
	public Texture normal;
	public Texture pcp;

	void Start(){
		renderer.material.mainTexture = normal;
	}
	// Update is called once per frame
	void Update () { 
		//Debug.Log (""+dir);
		if (changeDir) 
		{
			changeDir = false;
			if (dir == 0) {
					//pos.y = 0;
					rigidbody2D.AddForce (new Vector2 (speed, 0));
			} else if (dir == 1) {
					//pos.y = 0;
					rigidbody2D.AddForce (new Vector2 (speed * -1, 0));
			}
			if (dir == 2) {
					//pos.x = 0;
					rigidbody2D.AddForce (new Vector2 (0, speed));
			} else if (dir == 3) {
					//pos.x = 0;
					rigidbody2D.AddForce (new Vector2 (0, speed * -1));
			} 
		}
		BoxCollider2D colliders = collider2D as BoxCollider2D;
		float temp1 = Random.Range (0.60f, 1.0f);
		float temp2 = Random.Range (0.60f, 1.0f);
		colliders.size = new Vector2(temp1,temp2);

		if (GameManager.pcpStatus ()) {
			renderer.material.mainTexture = pcp;
		} else {
			renderer.material.mainTexture = normal;
		}
	
	}
	void OnCollisionEnter2D(Collision2D other){
	
		int temp = dir;
		while (temp == dir)
		{
			temp = Random.Range (0, 4);
		}
		dir = temp;	
		rigidbody2D.velocity = Vector2.zero;
		changeDir = true;

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "oneWayDoor") {
			Vector3 pos = transform.position;
			pos.x = -0.619683f;
			pos.y = 1.95f;
			pos.z = 0.0f;
			transform.position = pos;
			rigidbody2D.AddForce(new Vector2(speed*-1,0));
		}

		if (other.gameObject.name == "leftPort") {
			Vector3 pos = transform.position;
			pos.x *= -1;
			transform.position = pos;
		}
		if (other.gameObject.name == "rightPort") {
			Vector3 pos = transform.position;
			pos.x *= -1;
			transform.position = pos;
		}
	}
}
