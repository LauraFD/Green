using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AreaGreenB : MonoBehaviour {

	public ParticleSystem green;
	public GameObject enemy;

	private int lifeGreen = 2000;
	private int auxLifeGreen;


	void Start () 
	{
		green.Stop ();
	}


	public void LifeGB (int damage)
	{			
		lifeGreen -= damage;
		if (lifeGreen >= 0) 
		{
			lifeGreen -= damage;
			if (lifeGreen <= 0) 
			{
				green.Stop ();
				SceneManager.LoadScene ("Menu");

			}
		}
	}
	public void Particle()
	{
		green.Play ();
	}
}
