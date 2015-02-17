using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float linearSpeed = 10f;
	public Transform groundChecker;
	public float maxJumpHeight = 3f;
	public GameObject kickParticles;
	public AudioClip whooshSound;		
	public GameObject cactusDestroyParticles;

	private bool canJump = false, canKick;
	private Animator anim;
	private float distanceToGround = 0f;

	private bool kicking, jumping, running;

	public int jumpScore = 1;
	public int kickScore = 1;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		RaycastHit2D hit = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));
		distanceToGround = ((Vector2) transform.position - hit.point).magnitude;
		anim.SetFloat("DistanceToGround", distanceToGround);
		anim.SetFloat("VerticalSpeed", rigidbody2D.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(running && Input.GetButtonDown("Jump")) canJump = true;
		else if(Input.GetButtonUp("Jump")) canJump = false;

		if(Input.GetButtonDown("Kick")) canKick = true;
		else if(Input.GetButtonUp("Kick")) canKick = false;

		running = distanceToGround < 0.5f;
		jumping = canJump && distanceToGround < maxJumpHeight;
		kicking = !running && canKick;

		if(running) rigidbody2D.velocity = new Vector2(linearSpeed, rigidbody2D.velocity.y);

		if (jumping) { // We are jumping if the user is holding the jump button and NotA
			// allow kicking ONLY
			// can switch to running if we are near the ground
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5);
			jumpScore++;
		} 
		if (kicking) { // We are kicking if the user is holding the kick button and NotA
			// allow NOTHING
			// can switch to running if we are near the ground
			kickParticles.particleSystem.Emit(1);
			anim.SetBool("Punching", true);
			rigidbody2D.velocity = new Vector2(linearSpeed * 1.5f, -1);
			kickScore++;
		} else anim.SetBool("Punching", false);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(kicking && other.gameObject.tag.Equals("Ground")) {
			Destroy(other.transform.parent.gameObject);
			Instantiate(cactusDestroyParticles, other.transform.position, Quaternion.identity);
			kicking = false;
		}
	}
}
