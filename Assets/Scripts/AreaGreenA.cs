using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class AreaGreenA : MonoBehaviour 
{ 
	public ParticleSystem green;

	private int lifeGreen = 1000;
	private int auxLifeGreen;
	private GameObject enemy;

	void Start () 
	{
		enemy = GameObject.FindWithTag ("Enemy");
	}


	public void LifeG (int damage)
	{			
		lifeGreen -= damage;
		if (lifeGreen >= 0) 
		{
			lifeGreen -= damage;
			Debug.Log ("vida " + lifeGreen);
			if (lifeGreen == 0) 
			{
				green.Stop ();
				enemy.SendMessage ("DestroyAreaG");

			}
		}
	}


}