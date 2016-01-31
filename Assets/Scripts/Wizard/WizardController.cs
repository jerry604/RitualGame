using UnityEngine;
using System.Collections;

public class WizardController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;

    public float wizardX;
    public float wizardY;
	public float moveForce = 30f;
	public float maxSpeed = 10f;
	public float jumpForce = 1000f;

	public Transform groundCheck;

    public float minCameraX;
    public float maxCameraX;

	private bool onLadder = false;
    private bool grounded = false;
	private Rigidbody2D rb2d;
    private Animator anim;
	private int count ;
	private string objectTag;

	public string getTagName(){
		return objectTag;
	}

    void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
        wizardX = transform.position.x;
        wizardY = transform.position.y;

		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

        if (Input.GetButton("Horizontal") && grounded)
        {
            if (h > 0)
            {
                anim.Play("walkRight");
            }
            if( h < 0 )
            {
                anim.Play("walkLeft");
            }
        }
        

        if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce (Vector2.right * h * moveForce);
		} 

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

		if (jump) {
			rb2d.AddForce(new Vector2(0f, jumpForce));
            /* Apply motion */
            //Vector2 _velocity = rb2d.velocity;
            //Vector2 target = new Vector2(0, 5);
            //Vector2 _velocityChange = ( target - _velocity);

            /* Move rigidbody */
            //rb2d.AddForce(_velocityChange, ForceMode.VelocityChange);
            jump = false;
		}

        if( !Input.GetButton("Horizontal"))
        {
            if(grounded)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            if(rb2d.velocity.y == 0)
            {
                anim.Play("idle");
            }
        }
        if (!grounded)
        {
            if (h > 0)
            {
                anim.Play("jumpRight");
            }
            if (h < 0)
            {
                anim.Play("jumpLeft");
            }
        }

		if (onLadder) {
			rb2d.gravityScale = 0;
			rb2d.velocity = new Vector2 (h * maxSpeed, v * maxSpeed);
			jump = false;
		} else {
			rb2d.gravityScale = 5;
		}
    }
		

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Ladder")) {
			onLadder = true;
		}

		if (other.gameObject.tag == "Skull" || 
			other.gameObject.tag == "Coin" ||
			other.gameObject.tag == "Bikini" ||
			other.gameObject.tag == "Chalk" ||
			other.gameObject.tag == "Candle" )
		{
			other.gameObject.SetActive (false);
			objectTag = other.gameObject.tag;
					count++;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Ladder")) {
			onLadder = false;
		}
	}

	void OnGUI()
	{
		GUILayout.Label( "Item Picked Up: " + objectTag);
	}
}

