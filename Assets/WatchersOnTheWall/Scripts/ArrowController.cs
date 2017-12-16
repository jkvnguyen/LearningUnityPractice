using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	public Rigidbody arrow;
	public Transform shotSpawn;

	float fireRate = 0.5f;
	float nextFire;

	private float shotPower = 2000.0f;

	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f, 0));


		if(Physics.Raycast(ray.origin, Camera.main.transform.forward, out hit, 1000.0f)){
			Debug.DrawLine(ray.origin, hit.point, Color.green);

		}
			
		if(Input.GetButton("Fire1") && shotPower < 3000.0f){

			shotPower += 100;
			//Mathf.Clamp (shotPower, 0, 1500.0f); 


		}

		if(Input.GetButtonUp("Fire1") && Time.time > nextFire){


			Rigidbody cloneRb = Instantiate (arrow, shotSpawn.position, shotSpawn.rotation) as Rigidbody; 
			//Rigidbody cloneRb = Instantiate (arrow, shotSpawn.position, Quaternion.LookRotation(hit.point)) as Rigidbody;
			//Transform temp = 
			cloneRb.AddForce (shotSpawn.transform.right * -shotPower);

			//cloneRb.AddForceAtPosition((hit.point - ray.origin) * shotPower, shotSpawn.position);
			nextFire = Time.time + fireRate;
			shotPower = 2000.0f;


		}

	}
		
}
