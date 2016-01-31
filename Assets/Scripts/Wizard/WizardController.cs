using UnityEngine;
using System.Collections;

public class WizardController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;

	public Vector2 playerSpawn;

    public float wizardX;
    public float wizardY;
	public float moveForce = 30f;
	public float maxSpeed = 10f;
	public float jumpForce = 1000f;

	public Transform groundCheck;

	private bool onLadder = false;
    private bool grounded = false;
	private Rigidbody2D rb2d;
    private Animator anim;

	private int count = 0;
	private string objectTag = "";

	public AudioSource success;
	public AudioSource fail;
	public AudioSource footstep;
	public AudioSource ladder;

    void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D> ();
		footstep.Play ();
		footstep.Pause ();
		ladder.Play ();
		ladder.Pause ();
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

		rb2d.velocity = new Vector2 (h * maxSpeed, rb2d.velocity.y);
        
		if (jump) {
			rb2d.AddForce(new Vector2(0f, jumpForce));
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
		if (!grounded) {
			footstep.Pause ();

			if (h > 0) {
				anim.Play ("jumpRight");
			}
			if (h < 0) {
				anim.Play ("jumpLeft");
			}
		} else {
			if (rb2d.velocity.x != 0) {
				if (!footstep.isPlaying) {
					footstep.UnPause ();
				}
			} else {
				footstep.Pause ();		
			}
		}

		if (onLadder) {
			rb2d.gravityScale = 0;
			rb2d.velocity = new Vector2 (h * maxSpeed, v * maxSpeed);
			jump = false;

			if (rb2d.velocity.y != 0) {
				if (!ladder.isPlaying) {
					ladder.UnPause ();
				}
			} else {
				ladder.Pause ();		
			}
		} else {
			rb2d.gravityScale = 10;
		}


			
    }

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Ladder")) {
			onLadder = true;
		}

		if (other.gameObject.CompareTag ("Skull") ||
		    other.gameObject.CompareTag ("Coin") ||
		    other.gameObject.CompareTag ("Bikini") ||
		    other.gameObject.CompareTag ("Chalk") ||
		    other.gameObject.CompareTag ("Candle")) {

			other.gameObject.SetActive (false);
			objectTag = other.gameObject.tag;
			count = count + 1;
		}

		/// Death
//		if (other.gameObject.CompareTag ("Destroyer") || other.gameObject.CompareTag("Flame")) {
//			gameObject.transform.position = new Vector3(playerSpawn.x, playerSpawn.y, 1f);
//		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Ladder")) {
			onLadder = false;
		}
	}

	public string getTagName() 
	{
		return objectTag;
	}

	void OnGUI()
	{
		GUILayout.Label ("Item Picked Up: " + objectTag);
	}
}
