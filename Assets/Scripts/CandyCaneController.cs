using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCaneController : MonoBehaviour {
	//Public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float startY = 381;
	[SerializeField]
	private float endY = -388;

	// Private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}
		
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
		
	private void Reset(){
		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 300);
		_currentPos = new Vector2 (startX + dx, y);
	}
}
