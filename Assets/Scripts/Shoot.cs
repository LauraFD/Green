using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
   	private float rayDistance=10;
	public float damageS; 

    private GameObject tmpCrosshair;
    private Camera currentCamera;
    private Ray mouseRay;
    private RaycastHit rayHit;
    private Ray crossRay;



    // Use this for initialization
    void Start()
    {
        currentCamera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetMouseButtonDown (0))
			LauchRaycast ();
    }


    private void LauchRaycast()
    {
        //obtener el Rayo
        mouseRay = currentCamera.ScreenPointToRay(Input.mousePosition);

        //lanzar raycast
        if (Physics.Raycast(mouseRay, out rayHit, rayDistance))
        {
            if (rayHit.transform.tag == "Enemy")
            {
				print ("Disparo");
				rayHit.transform.SendMessage ("Shooting", damageS);
                             
            }
        }

    }
}
