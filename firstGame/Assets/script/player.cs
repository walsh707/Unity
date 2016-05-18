using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    
   
	public static float MIN_X_BOUNDS; 
	public static float MAX_X_BOUNDS;

	public Text tallyText;
	public Image healthBarImage;
	public float currentHealth = 50;
	public float totalHealth = 100;
	public int collectCount = 0;

	public AudioSource aSource;
	public AudioClip EatSound;
	public AudioClip CollectSound;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();



		MIN_X_BOUNDS = -(Camera.main.aspect * Camera.main.orthographicSize);
		MAX_X_BOUNDS = Camera.main.aspect * Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		tallyText.text = collectCount.ToString ();
		healthBarImage.fillAmount = currentHealth / totalHealth;
		currentHealth = Mathf.Clamp (currentHealth, 0, totalHealth);
       

			
		//While holding the 'S' Key
		if (Input.GetKey (KeyCode.S)) {
			animator.SetBool ("IsDucking", true);
		} else {
			animator.SetBool ("IsDucking", false);
		}

		if (currentHealth <= 0) {
			SceneManager.LoadScene ("GameOver");
		} else if (collectCount >= 7)
			SceneManager.LoadScene ("WinGame");
		
	}

	public void PlayEatSound(){
		aSource.PlayOneShot (EatSound);
	}
	public void PlayCollectSound(){
		aSource.PlayOneShot(CollectSound);
	}
}
