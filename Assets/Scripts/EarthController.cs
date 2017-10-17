/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: EarthController
 * Description: This class acts as the controller to the background of
 * 		the game. It handles its movement from right to left and the
 * 		speed in which this scrolling happens.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f; //Speed in which the background moves
	[SerializeField]
	private float startX; //Initial position (x-axis) of the background
	[SerializeField]
	private float endX; //End position (x-axis) of the background

	private Transform _transform;
	private Vector2 _curPosition;

	/* This method is called once in the initialization of the game. */
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_curPosition = _transform.position;

		Reset ();
	}
	
	/* Updates the screen. Called once per frame. */
	void Update () {
		_curPosition = _transform.position;
		// Move the background from the right to the left
		_curPosition -= new Vector2 (speed, 0);

		if (_curPosition.x < endX) {
			Reset ();
		}

		_transform.position = _curPosition;
	}

	/* This method makes sure the background works in a scrolling fashion,
	 * by reseting its position to the its start point. */
	private void Reset(){
		_curPosition = new Vector2 (startX, 0);
	}
}
