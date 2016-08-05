using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuInterface : MonoBehaviour 
{
	public GameObject playButton;
	public GameObject exitButton;

	public void PlayGreen()
	{
		SceneManager.LoadScene ("GreenL1");
	}
	public void ExitGreen()
	{
		StartCoroutine ("PauseGreen");
		Application.Quit ();
	}

	IEnumerator PauseGreen()
	{
		yield return new WaitForSeconds (15);
	}
}

