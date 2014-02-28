using UnityEngine;
using System.Collections;

public class MovingWalls : MonoBehaviour {
	public bool startDirectionUp;
	bool direction;


	// Use this for initialization
	void Start () {
		direction = !startDirectionUp;
			if (startDirectionUp) rigidbody2D.AddForce (new Vector2 (0, 99999));
			else rigidbody2D.AddForce (new Vector2 (0, -99999));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.name != "player" && collider.gameObject.name != "npc") 
		{
			rigidbody2D.velocity = Vector2.zero;

			if (direction) rigidbody2D.AddForce (new Vector2 (0, 99999));
			else rigidbody2D.AddForce (new Vector2 (0, -99999));

			direction = !direction;
		}
	}
}
