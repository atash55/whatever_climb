using UnityEngine;
using System.Collections;

public class WinLoseDetector : MonoBehaviour
{
	public CollisionDetector deathZoneCollider;
	public CollisionDetector summitZoneCollider;

	void OnEnable()
	{
		deathZoneCollider.onTriggerEnter2D += EnteredDeathZone;
		summitZoneCollider.onTriggerEnter2D += EnteredSummitZone;
	}

	void OnDisable()
	{
		deathZoneCollider.onTriggerEnter2D -= EnteredDeathZone;
		summitZoneCollider.onTriggerEnter2D -= EnteredSummitZone;
	}

	static WinLoseDetector inst;
	void Awake()
	{
		inst = this;
	}

	public static void KillPlayer(Collider2D other)
	{
		inst.EnteredDeathZone(other);
	}

	void EnteredDeathZone( Collider2D other )
	{
		if(!deathZoneCollider.collider2D.enabled || !summitZoneCollider.collider2D.enabled)
			return;

		if( other.transform.parent.name == "Climber1" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(true);
			deathZoneCollider.collider2D.enabled = false;
			summitZoneCollider.collider2D.enabled = false;
		}
		else if( other.transform.parent.name == "Climber2" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(false);
			deathZoneCollider.collider2D.enabled = false;
			summitZoneCollider.collider2D.enabled = false;
		}
	}
	
	void EnteredSummitZone( Collider2D other )
	{
		if(!deathZoneCollider.collider2D.enabled || !summitZoneCollider.collider2D.enabled)
			return;
		Debug.Log("ghq3784yufrf");
		if( other.transform.parent.name == "Climber1" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(false);
			deathZoneCollider.collider2D.enabled = false;
			summitZoneCollider.collider2D.enabled = false;
		}
		else if( other.transform.parent.name == "Climber2" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(true);
			deathZoneCollider.collider2D.enabled = false;
			summitZoneCollider.collider2D.enabled = false;
		}
	}
}
