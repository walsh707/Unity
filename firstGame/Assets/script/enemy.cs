using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<player> ().currentHealth -= 5;
			Debug.Log
				("Collided with" + coll.gameObject.tag);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
