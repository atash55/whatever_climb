using UnityEngine;
using System.Collections;
using System;

public class CollisionDetector : MonoBehaviour
{
	public Action<Collider2D> onTriggerEnter2D;
	public Action<Collider2D> onTriggerExit2D;
	public Action<Collision2D> onCollsionEnter2D;

	void OnTriggerEnter2D (Collider2D other)
	{
		//Debug.Log(other.name);
		if(onTriggerEnter2D != null)
			onTriggerEnter2D(other);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		Debug.Log(other.name+ " Exit");
		if(onTriggerExit2D != null)
			onTriggerExit2D(other);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(onCollsionEnter2D != null)
			onCollsionEnter2D(other);
	}
}
