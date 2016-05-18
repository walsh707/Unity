using UnityEngine;
using System.Collections;



public class Main : MonoBehaviour {


	public GameObject player; 
	public GameObject[] backgroundObjectArray;

	int backgroundIndex = 1;
	float backgroundSize;

	public GameObject[] enemyArray = new GameObject[2];

    // Use this for initialization
    void Start () {
		backgroundSize = backgroundObjectArray [0].GetComponent<SpriteRenderer> ().bounds.size.x;
	
	}
	
	// Update is called once per frame
	void Update () {
        
	




		Follow (); 
		ScrollingBackground ();
	
	}

	void Follow(){
		if (player.transform.position.x >= 0) {
			Vector3 cameraPos = Camera.main.transform.position;
			Camera.main.transform.position = new Vector3 (player.transform.position.x, cameraPos.y, cameraPos.z);
		}
	}

	void 
	ScrollingBackground()
	{
		GameObject rightBackground = backgroundObjectArray [backgroundIndex];
		GameObject leftBackground = backgroundObjectArray [  
				(backgroundIndex>=backgroundObjectArray.Length-1) ? 0 : backgroundIndex+1 ];
		if (player.transform.position.x >= rightBackground.transform.position.x) 
		{
			if (backgroundIndex < backgroundObjectArray.Length-1)backgroundIndex++;
			else
				backgroundIndex = 0;backgroundObjectArray [backgroundIndex].transform.position = new Vector3 (rightBackground.transform.position.x + backgroundSize,rightBackground.transform.position.y, 0f);
		}
		else if (player.transform.position.x < leftBackground.transform.position.x && player.transform.position.x>0) 
		{
			backgroundObjectArray [backgroundIndex].transform.position = new Vector3 (leftBackground.transform.position.x-backgroundSize,leftBackground.transform.position.y, 0f);
		}
	}

}
