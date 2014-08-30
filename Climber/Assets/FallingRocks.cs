using UnityEngine;
using System.Collections;

public class FallingRocks : MonoBehaviour
{
	//Rigidbody2D[] rocks;
	// Use this for initialization
	IEnumerator Start ()
	{
		//rocks = GetComponentsInChildren<Rigidbody2D>();
		yield return new WaitForSeconds(3f);

//		foreach( Rigidbody2D r in rocks )
//			r.isKinematic = true;
//
//
//
//		foreach( Rigidbody2D r in rocks )
//		{
//			yield return new WaitForSeconds(Random.Range(0, 1f));
//			r.isKinematic = false;
//		}
	}

}
