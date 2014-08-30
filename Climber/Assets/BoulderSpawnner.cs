using UnityEngine;
using System.Collections;

public class BoulderSpawnner : MonoBehaviour
{
	Rigidbody2D boulder;
	Transform[] spawnPoints;
	// Use this for initialization
	void Start ()
	{
		spawnPoints = new Transform[3];
		spawnPoints[0] = transform.Find("Spawn01");
		spawnPoints[1] = transform.Find("Spawn02");
		spawnPoints[2] = transform.Find("Spawn03");

		boulder = transform.Find("_Boulder").rigidbody2D;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			boulder.transform.position = spawnPoints[ Mathf.RoundToInt( Random.Range(0f, 200f)/100f ) ].position;
			boulder.isKinematic = false;
			this.collider2D.enabled = false;
		}
	}
}
