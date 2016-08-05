using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Garb8Controller : MonoBehaviour
{
	
	public Text coinsLabel;
	public RectTransform lifeBar;
	public GameObject panelW;

	private float damageS=50;
	private int coins;
	private float lifePoints = 1000;
	private float speedMovement = 2;
	private float speedRotation = 30; 
	private float anglex;
	private float maxLife;
    private Vector3 vectorMovement;
	private RaycastHit hit;
	private CharacterController character;

	void Start ()
    {
		maxLife = lifePoints;
        character = GetComponent<CharacterController>();
		if (!PlayerPrefs.HasKey ("Coins")) {
			coins = 10;

		} else {
			coins = PlayerPrefs.GetInt ("Coins");
			PlayerPrefs.DeleteAll ();
		}
	}
		
		
    void Update()
	{
		vectorMovement = Vector3.zero;
		vectorMovement = transform.forward * Input.GetAxis ("Vertical") * Time.deltaTime * speedMovement +
		transform.right * Input.GetAxis ("Horizontal") * Time.deltaTime * speedMovement;
		if (!character.isGrounded)
			vectorMovement.y -= 0.1f;
		character.Move (vectorMovement);

		transform.Rotate (Vector3.up * speedRotation * Time.deltaTime * Input.GetAxis ("Mouse X"));


		if (Input.GetKey (KeyCode.LeftShift))
			speedMovement = 10;
		else
			speedMovement = 2;

		coinsLabel.text = "$ " + coins;

	}
		
	void  OnTriggerEnter(Collider colliderTrigger)
	{
		print ("Colision");
		if (colliderTrigger.transform.tag == "Coin") 
		{
			Destroy (colliderTrigger.gameObject);
			coins++;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.Save ();
			//PlayerPrefs.DeleteAll ();
		}

		if (colliderTrigger.transform.tag == "ItemA") 
		{
			Destroy (colliderTrigger.gameObject);
			lifePoints += 5;
			print ("Vida aumentada" + lifePoints);

			PlayerPrefs.Save ();
			//PlayerPrefs.DeleteAll ();
		}
		if (colliderTrigger.transform.tag == "ItemB") 
		{
			Destroy (colliderTrigger.gameObject);
			lifePoints += 10;
			print ("Vida aumentada" + lifePoints);

			PlayerPrefs.Save ();
			//PlayerPrefs.DeleteAll ();
		}


		if (colliderTrigger.transform.tag == "Win") 
		{
			StartCoroutine ("Pause");
			SceneManager.LoadScene ("GreenL2");
		}
		if (colliderTrigger.transform.tag == "WinLevel2") 
		{
			print ("Nivel2");
			Time.timeScale = 0;
			StartCoroutine ("Pause");
			panelW.SetActive (true);

		}
	}


	public void LifePlayer(float damageP)
	{
		lifePoints -= damageP;
		lifeBar.localScale = new Vector3 (lifePoints / maxLife, 1.0f, 1.0f);

		if (lifePoints <= 0) 
		{
			lifeBar.localScale = new Vector3 (0.0f, 1.0f, 1.0f);
			StartCoroutine ("Pause");
			SceneManager.LoadScene ("Menu");
		}
	}

	IEnumerator Pause()
	{
		yield return new WaitForSeconds (10);
	}

}

