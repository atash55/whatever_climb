﻿using UnityEngine;
using System.Collections;

public class Climber : MonoBehaviour
{

	Vector2 directionalInput = new Vector2();

	public CollisionDetector grabColliderDetector;
	public Collider2D grabCollider;
	public Collider2D charCollider;

	public Animator anim;

	SpringJoint2D springJoint;
	public bool canJump;

	string playerNumber;

	public AudioClip jumpAudio;
	public AudioClip hit1Audio;

	static Climber inst;
	void Awake ()
	{
		inst = this;
		Application.targetFrameRate = 60;
		springJoint = GetComponent<SpringJoint2D>();

		playerNumber = name[7].ToString();
	}

	public static void DisableScript()
	{
		inst.grabCollider.enabled = true;
		//inst.enabled = false;
	}

	void OnEnable ()
	{
		grabColliderDetector.onCollsionEnter2D += GrabColliderEnter;
	}
	void OnDisable ()
	{
		grabColliderDetector.onCollsionEnter2D -= GrabColliderEnter;
	}

	void GrabColliderEnter(Collision2D other)
	{
		//Debug.Log(other.collider.name);
		if(other.collider.CompareTag("Ledge"))
		{
			canJump = true;
			anim.SetBool("Jumping", false);
		}
		else if(other.collider.CompareTag("Falling Hazard"))
		{
			WinLoseDetector.KillPlayer( grabCollider );
			DisableGrab();
			audio.PlayOneShot( hit1Audio );
		}

	}

	void DisableGrab()
	{
		if(grabCollider.gameObject.activeSelf == false)
			return;
		grabCollider.gameObject.SetActive( false );
	}

	void Update ()
	{


		//Debug.Log(directionalInput + "" + Input.GetButton("Jump"+playerNumber));

		Vector2 rInp = Vector2.zero;
		bool jumpKeyDown = false;

		if(playerNumber == "1")
		{
			rInp.x = Input.GetKey(KeyCode.A)? -1:0;
			rInp.x += Input.GetKey(KeyCode.D)? 1:0;
			jumpKeyDown = Input.GetKeyDown(KeyCode.W);
		}
		if(playerNumber == "2")
		{
			rInp.x = Input.GetKey(KeyCode.LeftArrow)? -1:0;
			rInp.x += Input.GetKey(KeyCode.RightArrow)? 1:0;
			jumpKeyDown = Input.GetKeyDown(KeyCode.UpArrow);
		}



		var jumpVel = Vector3.zero;
		if( jumpKeyDown && canJump == true)
		{
			anim.SetBool("Jumping", true);
			//rigidbody2D.velocity = new Vector2 (rInp.x * 12.5f / (Mathf.Abs(rInp.y)*0.75f +1),  (20f - (Mathf.Abs(rInp.x)*10f)) * (Mathf.Abs(rInp.y*rInp.x)*1f +1));
			rigidbody2D.velocity = new Vector2( rigidbody2D.velocity.y, 20f);

			audio.PlayOneShot( jumpAudio );

			canJump = false;
		}

		//if( Mathf.Abs(rigidbody2D.velocity.y) < 0.01f)
			rigidbody2D.velocity = new Vector2( rInp.x * 4f ,rigidbody2D.velocity.y);



		grabCollider.enabled = rigidbody2D.velocity.y < 0.01f;

	}

	void FixedUpdate ()
	{

	}
}
