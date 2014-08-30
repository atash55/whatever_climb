using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

	public Transform target1;
	public Transform target2;
	public float smoothTime = 0.3f;
	public float yBias = 0;
	private Transform thisTransform;
	private Vector2 velocity;
	
	void Start()
	{
		thisTransform = transform;
	}
	
	void Update() 
	{
		var targetY = 0f;
		if(target2 != null)
			targetY = ((target1.position.y + target2.position.y)*0.5f) + yBias;
		else
			targetY = target1.position.y + yBias;

		thisTransform.position = new Vector3(thisTransform.position.x,
		                                     Mathf.SmoothDamp( thisTransform.position.y, targetY, ref velocity.y, smoothTime),
		                                     thisTransform.position.z);
	}
}
