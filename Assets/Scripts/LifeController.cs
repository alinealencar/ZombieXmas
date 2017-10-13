using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {
	//Public variables
	[SerializeField]
	float minYSpeed = -1f;
	[SerializeField]
	float maxYSpeed = 1f;
	[SerializeField]
	float minXSpeed = 5f;
	[SerializeField]
	float maxXSpeed = 10f;
	[SerializeField]

	// Private variables
	private Transform _transform;
	private Vector2 _curSpeed;
	private Vector2 _curPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	void Update () {
		_curPosition = _transform.position;
		_curPosition -= _curSpeed;

		// Apply changes
		_transform.position = _curPosition;

		if (_curPosition.x < -1127) {
			Reset ();
		}
	}

	public void Reset(){
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_curSpeed = new Vector2 (xSpeed, ySpeed);

		//Bolts show up going up or down
		float x = Random.Range(-381, 381);
		_transform.position = new Vector2 (x, -388 + Random.Range(0,100));
		Debug.Log(_transform.position.ToString());
	}
}
