using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		//if the bullet went outside the screen on the top, then destroy the bullet
		if(transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1,1)).x){
			Destroy (gameObject);
		}
	}
}
