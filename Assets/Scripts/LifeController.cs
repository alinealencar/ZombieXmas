/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: LifeController
 * Description: This class acts as the controller to the bolts that
 * 		generates points for the player. It handles its position 
 * 		(movement) in the screen, the speed in which it moves and 
 * 		random generation of new bolts.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {
	[SerializeField]
	float minYSpeed = -1f;
	[SerializeField]
	float maxYSpeed = 1f;
	[SerializeField]
	float minXSpeed = 5f;
	[SerializeField]
	float maxXSpeed = 10f;
	[SerializeField]

	private Transform _transform;
	private Vector2 _curSpeed;
	private Vector2 _curPosition;

	/* This method is called once in the initialization of the game. */
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	/* Updates the screen. Called once per frame. */
	void Update () {
		_curPosition = _transform.position;
		_curPosition -= _curSpeed;

		// Apply changes
		_transform.position = _curPosition;

		if (_curPosition.x < -1127) {
			Reset ();
		}
	}

	/* This method generates more bolts. */
	public void Reset(){
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_curSpeed = new Vector2 (xSpeed, ySpeed);

		//Bolts show up going up or down
		float x = Random.Range(-381, 381);
		_transform.position = new Vector2 (x, -388 + Random.Range(0,100));
	}
}
