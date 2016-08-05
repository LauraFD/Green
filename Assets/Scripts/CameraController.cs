using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	
	public float speedMovement;

	private float angle;
	private float min = -45.0f, max = 45.0f;

	void Update () 
	{
		transform.Rotate (Vector3.right * speedMovement * Time.deltaTime * (-Input.GetAxis ("Mouse Y")));
		angle = transform.localEulerAngles.x;
		angle = (angle > 180.0f) ? angle - 360.0f : angle;
		angle = Mathf.Clamp(angle, min, max);

		transform.localEulerAngles = new Vector3 (angle, transform.localEulerAngles.y, transform.localEulerAngles.z);

	}
}

