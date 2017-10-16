using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballController : MonoBehaviour {

	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float upperBound; 
	[SerializeField]
	private float lowerBound;

	private Transform _transform;
	private Vector2 _curPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_curPosition = _transform.position;
	}
	
	// Update is called once per frame
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

	private void CheckBounds(){
		if (_curPosition.y < lowerBound) {
			_curPosition.y = lowerBound;
		}

		if (_curPosition.y > upperBound) {
			_curPosition.y = upperBound;
		}
	}

}
