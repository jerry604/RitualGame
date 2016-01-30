using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {

	private float movex;
	private float movey;
	private float speed;
	private Rigidbody2D body;
	private Animator animation;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		speed = 1f;
		movex = 0f;
		movey = 0f;

		body = GetComponent<Rigidbody2D> ();
		animation = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
	}

	void FixedUpdate() {
		body.velocity = new Vector2 (movex * speed,body.velocity.y);
		animation.SetFloat("Speed", Mathf.Abs(movex));
	}
}
