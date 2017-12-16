using UnityEngine;
using System.Collections;

public class BarrelExplosion : MonoBehaviour {

	public GameObject explosion;
	public GameObject flames;

	private Rigidbody barrelRb;
	private bool explode;


	void Start () {
		barrelRb = GetComponent<Rigidbody> ();
		barrelRb.isKinematic = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Terrain") {
			explode = true;
			Instantiate (explosion, this.transform.position, this.transform.rotation);
			Instantiate (flames, this.transform.position, this.transform.rotation);
			Destroy (gameObject, 0.05f);
		}

	}

	void FixedUpdate()
	{
		if (explode) {
			Collider[] hitColliders = Physics.OverlapSphere (transform.position, 20);
			for (int i = 0; i < hitColliders.Length; i++) 
			{
				if (hitColliders [i].GetComponent<Rigidbody> () != null)
				{
					hitColliders [i].GetComponent<Rigidbody> ().AddExplosionForce (2000, transform.position, 20);
				}
			}

		} 
	}

	void Update(){
		if(Input.GetKeyDown("r")){
			barrelRb.isKinematic = false;
		}
	}


}
