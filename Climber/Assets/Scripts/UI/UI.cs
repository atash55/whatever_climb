using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	public Animation greenWinsAnim;
	public Animation blueWinsAnim;

	public Animation gameOverScreenAnim;

	static UI inst;

	void Awake ()
	{
		inst = this;
		//ShowWinScreen (true);
	}
	

	public static void ShowWinScreen (bool greenWins)
	{
		inst.StartCoroutine( inst._ShowWinScreen (greenWins) );
	}
	IEnumerator _ShowWinScreen (bool greenWins)
	{
		Animation anim = greenWins ? greenWinsAnim : blueWinsAnim;
		anim.Play();
		yield return new WaitForSeconds (4);
		foreach( AnimationState s in anim )
			s.speed = -1;
		anim.Play ();


	}

	void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	void LoadMainMenu()
	{
		Application.LoadLevel (0);
	}

	// Play
	// Help screen and back

}
