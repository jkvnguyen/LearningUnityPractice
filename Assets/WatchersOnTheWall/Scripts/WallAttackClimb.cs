using UnityEngine;
using System.Collections;

public class WallAttackClimb : MonoBehaviour {


	private GameObject arrow;
	private Rigidbody WildlingRb;
	private bool hit = false;
	private bool wallClimb = false;
	private bool onTerrain = false;

	void Start(){
		WildlingRb = GetComponent < Rigidbody> ();
	}
		

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Arrow") {
			arrow = other.gameObject.GetComponent<GameObject> ();
			hit = true; //if health is 0, then true

			Destroy(other.gameObject, 10-Time.deltaTime);
			Destroy(gameObject, 10);
		} 


	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "WallTrigger") {
			wallClimb = true;
		}

	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "WallTrigger") {
			WildlingRb.velocity = new Vector3(0, 0, 0);
			wallClimb = false;
		}

	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.tag == "Terrain") {
			onTerrain = true;
		} 

	}

	void FixedUpdate(){
		//WildlingRb.velocity = transform.right * -5;

	}

	void Update(){
		if (hit != true) {
			WildlingRb.velocity = transform.right * -5;
		} else {
			WildlingRb.velocity = new Vector3 (0, 0, 0);
		}

		if (onTerrain == true && wallClimb == true) {
			WildlingRb.velocity = new Vector3 (-5, 8, 0);
		}
			

	}

}
