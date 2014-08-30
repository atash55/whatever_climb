using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.009f;
	public float shake_intensity = 0.1f;

	static CameraShake inst;
	void Awake()
	{
		inst = this;
	}
	
	void Update ()
	{
		if (shake_intensity > 0)
		{
			var tmpPos =  Random.insideUnitSphere * shake_intensity;
			transform.localPosition = new Vector3(tmpPos.x, tmpPos.y, transform.localPosition.z);
//			transform.rotation =  Quaternion(  Random.Range(-shake_intensity,shake_intensity)*.2f,  
//			                                 	Random.Range(-shake_intensity,shake_intensity)*.2f,
//			                                 	Random.Range(-shake_intensity,shake_intensity)*.2f,  
//			                                 	Random.Range(-shake_intensity,shake_intensity)*.2f);

			shake_intensity -= shake_decay;
		}
	}

	public static void Shake(float intensity)
	{
		inst.shake_intensity = intensity;
	}
}

