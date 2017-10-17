/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: SnowBallController
 * Description: This class acts as the controller to the Snowball
 * 		character. It handles its position (movement) in the screen as
 * 		well as the speed in which it moves and the boundaries of the 
 * 		screen.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballController : MonoBehaviour {

	[SerializeField]
	private float speed = 7f; //Speed in which the character moves
	[SerializeField]
	private float upperBound; //Upper boundary of the screen
	[SerializeField]
	private float lowerBound; //Lower boundary of the screen

	private Transform _transform;
	private Vector2 _curPosition;

	/* This method is called once in the initialization of the game. */
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_curPosition = _transform.position;
	}

	/* Updates the screen. Called once per frame. */
	void Update () {
		_curPosition = _transform.position;
		// Move Mr. Snowball
		float userInput = Input.GetAxis("Vertical");

		if(userInput>0){
			// Press A, move him upwards
			_curPosition += new Vector2(0, speed);
		}
		if(userInput<0){
			// Press S, move him downwards
			_curPosition -= new Vector2(0, speed);
		}
		CheckBounds ();
		_transform.position = _curPosition;
	}

	/* Checks if the character is within the boundaries of the screen. */
	private void CheckBounds(){
		if (_curPosition.y < lowerBound) {
			_curPosition.y = lowerBound;
		}

		if (_curPosition.y > upperBound) {
			_curPosition.y = upperBound;
		}
	}

}
