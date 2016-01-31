using UnityEngine;
using System.Collections;

public class DestroyerController : MonoBehaviour {

	// Use this for initialization
	public Vector2 playerSpawn;

	public float flameYPos;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("Flame")) {
			float xPos = other.gameObject.transform.position.x;
			float zPos = other.gameObject.transform.position.z;
			other.gameObject.transform.position = new Vector3 (xPos, flameYPos, zPos);
		}
	
	}
}
