using UnityEngine;
using System.Collections;

public class CanGenerator : MonoBehaviour 
{
	public GameObject prefCan;

	private int aux = 0;
	private GameObject auxPrefab;

	void Start () 
	{
		
		InvokeRepeating ("CreateCan", 0.0f, 5);
		
	
	}
	
	void CreateCan()
	{
		if (aux <= 1) 
		{
			Instantiate (prefCan, transform.position, Quaternion.identity);
			aux++;
		}
	}

}
