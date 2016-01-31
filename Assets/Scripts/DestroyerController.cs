using UnityEngine;
using System.Collections;

public class DestroyerController : MonoBehaviour {

	// Use this for initialization
	public Vector2 playerSpawn;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("Player")) {
			/// show game over
			other.gameObject.transform.position = new Vector3(playerSpawn.x, playerSpawn.y, 1f);
		}

		if (other.gameObject.CompareTag ("Flame")) {
			float xPos = other.gameObject.transform.position.x;
			other.gameObject.transform.position = new Vector3 (xPos, 6.5f, 1f);
		}
	
	}
}
