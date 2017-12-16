using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BarrelController : MonoBehaviour {

	public GameObject canvas;
	bool temp;

	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			barrelDropEnable ();
		}

	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			barrelDropDisable ();
		}
	}

	void barrelDropEnable(){
		canvas.SetActive (true);
	}

	void barrelDropDisable(){
		canvas.SetActive (false);
	}


}
