using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GlobalAudioManager : MonoBehaviour 
{
	public AudioMixer globalMixer;
	public Slider globalSlider;
	public Slider musiclSlider;
	public Slider FxSlider;

	public void SetGlobalVolume ()
	{
		globalMixer.SetFloat ("masterVolume", globalSlider.value);
	}

	public void SetFxVolume ()
	{
		globalMixer.SetFloat ("soundFxVolume", FxSlider.value);
		Debug.Log (FxSlider.value);
	}
	public void SetMusicVolume ()
	{
		globalMixer.SetFloat ("musicVolume", musiclSlider.value);
	}
}
