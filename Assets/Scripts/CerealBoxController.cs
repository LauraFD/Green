using UnityEngine;
using System.Collections;

public class CerealBoxController : MonoBehaviour {
	
	public float patrolUpdate;
	public Vector2 areaPatrol;
	public GameObject prefabCereal;
	public RectTransform lifeBar;

	private float maxLifePoints;
	private float lifePoints=500;
	private Vector3 destination;
	private Vector3 startPosition;
	private GameObject auxPrefab;
	private GameObject areaB;
	private GameObject player;
	private GameObject enemy;
	private Animator enemyAnimator;
	private NavMeshAgent agent;
	private EnemyState currentState;



	void Start () 
	{
		
		maxLifePoints = lifePoints;
		startPosition = transform.position;
		agent = GetComponent<NavMeshAgent> ();
		enemyAnimator = GetComponent<Animator> ();


		currentState = EnemyState.PATROL;
		StartCoroutine("Punto");

		InvokeRepeating ("CreateCereal", 0.0f, 15);

	}



	void Update()
	{ 
		enemyAnimator.SetTrigger ("walkBox");	

	}

	void CreateCereal()
	{
		Instantiate (prefabCereal, transform.position, Quaternion.identity);
	}


	public void Shooting (float damageS)
	{
		print ("Disparo");
		lifePoints -= damageS;
		lifeBar.localScale = new Vector3 (1.0f, lifePoints / maxLifePoints, 1.0f);
		print (lifePoints);
		if (lifePoints <= 0) 
		{
			lifeBar.localScale = new Vector3 (1.0f, 0.0f, 0.0f);
			Death ();
		}
	}

	public void Death ()
	{		
		agent.Stop ();
		Destroy (this.gameObject, 0);
	}

	IEnumerator Punto()
	{
		destination = startPosition + new Vector3(Random.Range(-areaPatrol.x, areaPatrol.x), 0, Random.Range(-areaPatrol.y, areaPatrol.y));
		agent.SetDestination (destination);

		yield return new WaitForSeconds(patrolUpdate);
		if(currentState == EnemyState.PATROL) 
			StartCoroutine("Punto");

	}
	

}