using UnityEngine;
using System.Collections;

public class DestroyerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("Player")) {
			/// show game over
		}

		if (other.gameObject.CompareTag ("Flame")) {
			float xPos = other.gameObject.transform.position.x;
			other.gameObject.transform.position = new Vector3 (xPos, 6.5f, 1f);
		}
	
	}
}
