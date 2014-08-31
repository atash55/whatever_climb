using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

	void LoadLevel ()
	{
		Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Quit ()
	{
		Application.Quit();
	}
}
