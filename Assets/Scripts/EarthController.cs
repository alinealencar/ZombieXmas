using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour {

	// Public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	// Private variables
	private Transform _transform;
	private Vector2 _curPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_curPosition = _transform.position;

		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_curPosition = _transform.position;
		// Move the background from the right to the left
		_curPosition -= new Vector2 (speed, 0);

		if (_curPosition.x < endX) {
			Reset ();
		}

		_transform.position = _curPosition;
	}

	private void Reset(){
		_curPosition = new Vector2 (startX, 0);
	}
}
