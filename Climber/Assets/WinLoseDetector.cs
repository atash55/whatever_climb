using UnityEngine;
using System.Collections;

public class WinLoseDetector : MonoBehaviour
{
	public CollisionDetector deathZoneCollider;
	public CollisionDetector summitZoneCollider;

	void OnEnable()
	{
		deathZoneCollider.onTriggerEnter2D += EnteredDeathZone;
		//summitZoneCollider.onTriggerEnter2D += EnteredSummitZone;
	}

	void EnteredDeathZone( Collider2D other )
	{
		if( other.transform.parent.name == "Climber1" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(false);
		}
		else if( other.transform.parent.name == "Climber2" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(true);
		}
	}
	
	void EnteredSummitZone( Collider2D other )
	{
		if( other.name == "Climber1" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(true);
		}
		else if( other.name == "Climber2" )
		{
			Climber.DisableScript();
			UI.ShowWinScreen(false);
		}
	}
}
