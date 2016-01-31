using UnityEngine;
using System.Collections;

public class ShootingFlameController : MonoBehaviour {

	Rigidbody2D rb2d;
	public float speed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		rb2d.velocity = new Vector2 (0, speed);
	}

}
