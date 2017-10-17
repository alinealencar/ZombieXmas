/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: CandyCaneController
 * Description: This class acts as the controller to the Zombie Candy
 * 		Cane character (enemy). It handles its position (movement) in 
 * 		the screen, the speed in which it moves and random generation 
 * 		of new enemies.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCaneController : MonoBehaviour {
	[SerializeField]
	private float speed = 5f; //Speed in which the enemy moves
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float startY = 381;
	[SerializeField]
	private float endY = -388;

	private Transform _transform;
	private Vector2 _currentPos;

	/* This method is called once in the initialization of the game. */
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}
		
	/* Updates the screen. Called once per frame. */
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);

		// Check for the need to reset
		if (_currentPos.x < endX) {
			Reset ();
		}
		// Apply changes
		_transform.position = _currentPos;
	}
		
	/* This method generates more enemies. */
	private void Reset(){
		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 300);
		_currentPos = new Vector2 (startX + dx, y);
	}
}
