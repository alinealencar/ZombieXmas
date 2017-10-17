/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: SnowBallCollision
 * Description: This class acts as the collision control to the Snowball
 * 		character. It handles its collision with bolts and enemies.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballCollision : MonoBehaviour {
	//[SerializeField]
	//GameController gameController;

	//Animation
//	[SerializeField]
//	GameObject explosion;

	private AudioSource _mrCaneSound;
	private AudioSource _energySound;

	/* This method is called once in the initialization of the game. */
	void Start () {
		_mrCaneSound = gameObject.GetComponent<AudioSource> ();
		_energySound = gameObject.GetComponent<AudioSource> ();
	}

	/* Updates the screen. Called once per frame. */
	void Update () {

	}

	/* This method handles the collision of Mr. Snowball with bolts and enemies.
	 *  - Collision with bolts renders score increase.
	 *  - Collision with enemies renders the loss of 1 life.
	 *  - Both collisions trigger a sound effect. */
	public void OnTriggerEnter2D(Collider2D other){
		// Detect collision with Mr. Cane
		if (other.gameObject.tag.Equals ("cane")) {
			// Play sound
			if (_mrCaneSound != null) {
				_mrCaneSound.Play ();
			}
			Player.Instance.LoseLife ();
		}
		// Detect collision with bolts
		else if (other.gameObject.tag.Equals("energy")) {
			// Play sound
			if (_energySound != null) {
				_energySound.Play ();
			}
			//Animation
//			GameObject e = Instantiate (explosion);
//			e.GetComponent<Transform> ().position = 
//				other.gameObject.GetComponent<Transform> ().position;

			other.gameObject.GetComponent<LifeController> ().Reset(); //Pull bolt back to the top
			Player.Instance.Score += 100;

		}
	}
}