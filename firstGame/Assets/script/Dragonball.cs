using UnityEngine;
using System.Collections;

public class Dragonball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (5, -5);
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			Destroy (gameObject);

			//update the count
			coll.gameObject.GetComponent<player>().collectCount++;
			coll.gameObject.GetComponent<player>().currentHealth+=2;

			coll.gameObject.GetComponent<player> ().PlayEatSound ();
		}


	}





}
