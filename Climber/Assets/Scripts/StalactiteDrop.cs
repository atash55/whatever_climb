using UnityEngine;
using System.Collections;

public class StalactiteDrop : MonoBehaviour
{
	void OnTriggerExit2D( Collider2D other )
	{
		if(other.CompareTag("Player"))
		{
			animation.Play();
		}
	}
}
