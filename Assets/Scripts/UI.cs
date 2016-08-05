using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	private bool paused;

	// Use this for initialization
	void Start () 
	{
		paused = false;
	
	}
	void Update()
	{
		//paused = !paused;
		if (Input.GetKeyDown (KeyCode.Space)) 
				Time.timeScale = 0;

		
	
	}

	public void Pause ()
	{
		print (paused);
		paused = !paused;
		if (paused)
			Time.timeScale = 0;
		else if (!paused)
			Time.timeScale = 1;
	}

	public void Exit()
	{
		StartCoroutine ("PauseGreen");
		Application.Quit ();
	}

	public void Menu()
	{
		StartCoroutine ("PauseGreen");
		SceneManager.LoadScene ("Menu");
	}

	IEnumerator PauseGreen()
	{
		yield return new WaitForSeconds (10);
	}

}
