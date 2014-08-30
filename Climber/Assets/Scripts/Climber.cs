using UnityEngine;
using System.Collections;

public class Climber : MonoBehaviour
{

	Vector2 directionalInput = new Vector2();

	public CollisionDetector grabColliderDetector;
	public Collider2D grabCollider;
	public Collider2D charCollider;

	public Animator anim;

	SpringJoint2D springJoint;
	bool canJump;

	string playerNumber;

	void Awake ()
	{
		Application.targetFrameRate = 60;
		springJoint = GetComponent<SpringJoint2D>();

		playerNumber = name[7].ToString();
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
			EnableCharacterCollider();

	}

	void EnableCharacterCollider()
	{
		if(grabCollider.gameObject.activeSelf == false)
			return;
		StartCoroutine( _EnableCharacterCollider() );
	}
	IEnumerator _EnableCharacterCollider()
	{
		grabCollider.gameObject.SetActive( false );
//		charCollider.enabled = true;
		yield return new WaitForSeconds(0.2f);
//		charCollider.enabled = false;
	}

	void Update ()
	{

		directionalInput.x = Input.GetAxisRaw ("Horizontal"+playerNumber);
		directionalInput.y = Input.GetAxisRaw ("Vertical"+playerNumber);

		var rInp = new Vector2(); // roundeded off input
		if( Mathf.Abs(directionalInput.x) > 0.01f )
			rInp.x = Mathf.Sign( directionalInput.x );
		else
			rInp.x = 0;
		
		if( directionalInput.y > 0.01f )
			rInp.y = Mathf.Sign( directionalInput.y );
		else
			rInp.y = 0;

		if( Input.GetButtonDown ("Jump"+playerNumber) && canJump == true &&  Mathf.Abs( rigidbody2D.velocity.y ) < 0.01f)
		{
			anim.SetBool("Jumping", true);
			rigidbody2D.velocity = new Vector2 (rInp.x * 12.5f / (Mathf.Abs(rInp.y)*0.75f +1),  (20f - (Mathf.Abs(rInp.x)*10f)) * (Mathf.Abs(rInp.y*rInp.x)*1f +1));
			canJump = false;
		}

		grabCollider.enabled = rigidbody2D.velocity.y < 0.01f;

	}

	void FixedUpdate ()
	{

	}
}
