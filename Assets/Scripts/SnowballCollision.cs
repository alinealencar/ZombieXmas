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

//	[SerializeField]
//	GameObject explosion;

	private AudioSource _mrCaneSound;
	private AudioSource _energySound;

	// Use this for initialization
	void Start () {
		_mrCaneSound = gameObject.GetComponent<AudioSource> ();
		_energySound = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D other){
		// Detect colision with Mr. Cane
		if (other.gameObject.tag.Equals ("cane")) {
			//Debug.Log ("Collision with Mr. Cane\n");
			// Play sound
			if (_mrCaneSound != null) {
				_mrCaneSound.Play ();
			}
			Player.Instance.LoseLife ();
		}
		//Add points
		else if (other.gameObject.tag.Equals("energy")) {
			//Debug.Log ("Collision with energy \n");

			// Play sound
			if (_energySound != null) {
				_energySound.Play ();
			}
//			GameObject e = Instantiate (explosion);
//			e.GetComponent<Transform> ().position = 
//				other.gameObject.GetComponent<Transform> ().position;

			other.gameObject.GetComponent<LifeController> ().Reset(); //pull bolt back to the top
			Player.Instance.Score += 100;

		}
	}
}