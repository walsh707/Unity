using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour {

	//variables
	const float PLAYER_NORMAL_SPEED = 5f;
	const float MIN_JUMP_FORCE = 5;
	const float PLAYER_EXTRA_SPEED = 10f;
	const float GROUND_Height = -2.8f;
	const float BULLET_SPEED = 5.0f;

	Animator animator;
	Rigidbody2D rigidBody;
	SpriteRenderer sRenderer;

	public GameObject playerBullet;
	List <GameObject> bulletList = new List<GameObject> ();

	public GameObject Dragonball;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		sRenderer = GetComponent<SpriteRenderer>();


	}

	// Update is called once per frame
	void Update () {
		
		//while holding "S"
		if(Input.GetKey (KeyCode.S))
		{
			animator.SetBool ("IsDucking", true);
		}
		//while not holding "S"
		else
		{
			animator.SetBool("IsDucking", false);
		}

		//Jumping key input
		if (Input.GetKeyDown (KeyCode.W) && !animator.GetBool ("IsJumping")) {
			animator.SetBool ("IsJumping", true);
			rigidBody.AddForce (new Vector2 (0, MIN_JUMP_FORCE), ForceMode2D.Impulse);
			rigidBody.gravityScale = 0.7f;
		}

		//Force the player from falling below this hieght
		//if (transform.position.y < GROUND_Height) 
		//{
		//	rigidBody.velocity = new Vector3 (rigidBody.velocity.x, 0, 0);
		//	transform.position = new Vector3 (transform.position.x, GROUND_Height, 0);
		//	animator.SetBool ("IsJumping", false);
		//	rigidBody.gravityScale = 0;
		//}
				


		//Flip image if holding Right or Left
		if (Input.GetAxis ("Horizontal") > 0) {
			sRenderer.flipX = false;
			animator.SetBool ("IsRunning", true);
		} 
		else if (Input.GetAxis ("Horizontal") < 0) {
			sRenderer.flipX = true;
			animator.SetBool ("IsRunning", true);

		} else
			animator.SetBool ("IsRunning", false);		

		if(transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1,1)).x){
			Destroy (gameObject);
		}
		
	}


	//check is player collides with ground
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "ground")
			animator.SetBool ("IsJumping", false);

		//Dragonball appears when plyer collides with block
		if (coll.gameObject.tag == "QuestionBlock") {
			Instantiate (Dragonball, coll.gameObject.transform.position + new Vector3(0,1,0), Quaternion.identity);
			GetComponent<player> ().PlayCollectSound ();

		}
	}


	void FixedUpdate()
	{
		if (animator.GetBool ("IsDucking")) {
			rigidBody.velocity = new Vector3 (0, rigidBody.velocity.y, 0);			
		} else if (Input.GetAxis ("Horizontal") < 0) {
			rigidBody.velocity = new Vector3 (Input.GetAxis ("Horizontal") * PLAYER_NORMAL_SPEED, rigidBody.velocity.y, 0);
		} else if (Input.GetAxis ("Horizontal") > 0) {
			rigidBody.velocity = new Vector3 (Input.GetAxis ("Horizontal") * PLAYER_NORMAL_SPEED, rigidBody.velocity.y, 0);
		} else {
			rigidBody.velocity = new Vector3 (0f, rigidBody.velocity.y, 0f);
		}


		//player taps the F key to fire the projectile if
		if (Input.GetKeyDown (KeyCode.F)) {
			animator.SetBool ("IsAttacking", true);

			Vector3 spawnPos = gameObject.transform.position + new Vector3 (1f, 0.2f, 0);

			GameObject bullet = (GameObject)Instantiate (playerBullet, spawnPos, Quaternion.identity);
			bulletList.Add (bullet);
			SpriteRenderer bRenderer = bullet.GetComponent<SpriteRenderer> ();
			Rigidbody2D bRigidBody = bullet.GetComponent<Rigidbody2D> ();

			if (transform.position.x > Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)).x) {
				Destroy (gameObject);
			}

			if (sRenderer.flipX) {
				bRigidBody.AddForce (Vector2.left * BULLET_SPEED, ForceMode2D.Impulse);
				bRenderer.flipX = false;
			} else {
				bRigidBody.AddForce (Vector2.right * BULLET_SPEED, ForceMode2D.Impulse); 
				bRenderer.flipX = true;
			}
		

		} else {
			animator.SetBool ("IsAttacking", false);
		}



	}



}




