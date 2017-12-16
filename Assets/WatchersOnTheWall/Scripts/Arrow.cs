using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	private Rigidbody rb;
	private Collider col;
	private Transform hit;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<Collider> ();
		//Destroy (gameObject, 10);
	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "Terrain") {
			col.isTrigger = false;
			rb.detectCollisions = false;
			rb.isKinematic = true;
			Destroy (col);
		}

		if (other.gameObject.tag == "Wildling1") {
			col.isTrigger = false;
		}
			
	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "Wildling1"){

			//The piercing is not perfect because going from trigger to collision forces the arrow to pop out

			rb.isKinematic = true; //stops arrow from moving
			GameObject temp = new GameObject ("Temp"); //make temp gameObject
			temp.transform.position = other.contacts [0].point; //gets the point of intersection and set to temp
			temp.transform.rotation = this.transform.rotation; // "" ^
			temp.transform.parent = other.transform; //set the intersection and rotation of hit to wildling's transform
			this.hit = temp.transform; 

			Destroy (col);
			Destroy (gameObject, 10);

			//Destroy (other.gameObject, 10);


		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Wildling1") {
		//	Destroy (gameObject);
		}
	}
		
		
	void Update(){

		if (this.hit != null) {
			this.transform.position = hit.transform.position;
			this.transform.rotation = hit.transform.rotation;
		}

	}


}
