using UnityEngine;
using System.Collections;

public class AudioFXManager : MonoBehaviour
{
	public AudioClip[] soundFX;

	private AudioSource audioSource;

	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();
		
	
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
			audioSource.PlayOneShot (soundFX [0]);
	
	}
}
