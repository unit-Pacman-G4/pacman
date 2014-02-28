using UnityEngine;
using System.Collections;

public class NPC3D : MonoBehaviour {
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
		Vector3 pos = rigidbody.velocity;
		if (changeDir) 
		{
			changeDir = false;
			if (dir == 0) {
				//pos.y = 0;
				pos.z = 3;
			} else if (dir == 1) {
				//pos.y = 0;
				pos.z = -3;
			}
			if (dir == 2) {
				//pos.x = 0;
				pos.x = 3;
			} else if (dir == 3) {
				//pos.x = 0;
				pos.x = -3;
			} 
		}
		rigidbody.velocity = pos;

		//Dirtyfix for å ikke stoppe og bevege seg.
		BoxCollider colliders = collider as BoxCollider;
		float temp1 = Random.Range (0.5f, 2.0f);
		float temp2 = Random.Range (0.50f, 2.0f);
		float temp3 = Random.Range (0.50f, 2.0f);
		colliders.size = new Vector3(temp1,temp2,temp3);
		
		if (GameManager.pcpStatus ()) {
			renderer.material.mainTexture = pcp;
		} else {
			renderer.material.mainTexture = normal;
		}
		
	}
	void OnCollisionEnter(Collision other){
		//Debug.Log (other.gameObject.name);
		//if (other.gameObject.name != "bg") {
			int temp = dir;
			while (temp == dir)
			{
				temp = Random.Range (0, 4);
			}
			dir = temp;	
			rigidbody.velocity = Vector3.zero;
			changeDir = true;	
		//}

		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "oneWayDoor") {
			Vector3 pos = transform.position;
			pos.x = 4.429339f;
			pos.y = -0.2947361f;
			pos.z = -2.567645f;
			transform.position = pos;
			//rigidbody.AddForce(new Vector3(speed*-1,0,0));
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
