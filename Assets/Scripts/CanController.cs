using UnityEngine;
using System.Collections;
enum EnemyState { PATROL }

public class CanController : MonoBehaviour 
{
	public int damageAreaA;
	public int damageAreaB;
	public float damageP;
	public float patrolUpdate;
	public float lifePoints;
	public Vector2 areaPatrol;
	public RectTransform lifeBar;


	private float maxLifePoints;
	private bool auxAreaA;
	private bool auxAreaB;


	private Vector3 randomDestination;
	private Vector3 startPosition;
	private GameObject areaA;
	private GameObject areaB;
	private GameObject player;
	private GameObject enemy;
	private Animator enemyAnimator;
	private NavMeshAgent agent;
	private EnemyState currentState;

	void Start () 
	{
		auxAreaA = true;
		auxAreaB = false;
		maxLifePoints = lifePoints;
		startPosition = transform.position;

		agent = GetComponent<NavMeshAgent> ();

		areaA = GameObject.FindGameObjectWithTag ("AreaA");
		areaB = GameObject.FindGameObjectWithTag ("AreaB");
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyAnimator = GetComponent<Animator> ();

		currentState = EnemyState.PATROL;
		StartCoroutine("Patrol");
	
	}
	

	void Update() 
	{	
		
		if (auxAreaA == true) 
		{
			if (Vector3.Distance (agent.transform.position, areaA.transform.position) < 15f)
				StartCoroutine ("AttackAreaA");
		} 
		if (auxAreaB == true && auxAreaA == false)
			StartCoroutine ("AttackAreaB");

		if (Vector3.Distance (agent.transform.position, player.transform.position) < 10f)
			StartCoroutine ("AttackPlayer");
		enemyAnimator.SetTrigger ("walk");
		enemyAnimator.SetTrigger ("walkCereal");

	}

	IEnumerator Patrol()
	{
		randomDestination = startPosition + new Vector3(Random.Range(-areaPatrol.x, areaPatrol.x), 0, Random.Range(-areaPatrol.y, areaPatrol.y));
		agent.SetDestination (randomDestination);

		yield return new WaitForSeconds(patrolUpdate);
		if(currentState == EnemyState.PATROL) 
			StartCoroutine("Patrol");
		
	}

	IEnumerator AttackAreaA()
	{
		agent.SetDestination(areaA.transform.position);
		if (Vector3.Distance (agent.transform.position, areaA.transform.position) < 5f)
		{
			areaA.SendMessage ("LifeG", damageAreaA);

		}

		yield return new WaitForSeconds (0);
	}

	public void DestroyAreaG()
	{
		auxAreaA = false;
		auxAreaB = true;
		StopCoroutine ("AttackAreaA");
		areaB.SendMessage ("Particle");
	}
		

	public void Shooting (float damageS)
	{
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

	IEnumerator AttackPlayer()
	{
		agent.SetDestination(player.transform.position);
		if (Vector3.Distance (agent.transform.position, player.transform.position) < 2f)
			player.SendMessage ("LifePlayer",damageP);
		
		yield return new WaitForSeconds (0);
	}
		
	IEnumerator AttackAreaB()
	{
		agent.SetDestination(areaB.transform.position);
		if (Vector3.Distance (agent.transform.position, areaB.transform.position) < 5f)
		{
			areaB.SendMessage ("LifeGB", damageAreaB);
		}
		yield return new WaitForSeconds (0);
	}

}
