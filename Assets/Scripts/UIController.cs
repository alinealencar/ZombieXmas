using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	[SerializeField]
	GameObject candyCane;

	[SerializeField]
	Image life1;
	[SerializeField]
	Image life2;
	[SerializeField]
	Image life3;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameOverLabel;
	[SerializeField]
	Button resetBtn;



	private void initialize(){

		Player.Instance.Score = 0;

		gameOverLabel.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);

		life1.gameObject.SetActive (true);
		life2.gameObject.SetActive (true);
		life3.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
	}

	public void gameOver(){
		gameOverLabel.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		life1.gameObject.SetActive (false);
		life2.gameObject.SetActive (false);
		life3.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
	}

	public void updateUI(){

		scoreLabel.text = "Score: " + Player.Instance.Score;
		//lifeLabel.text = "Life: " + Player.Instance.Life;
	}

	public void loseLife(){
		if (life3.IsActive()) {
			life3.gameObject.SetActive (false);
		} 
		else if (life2.IsActive()) {
			life2.gameObject.SetActive (false);
		} 
		else if (life1.IsActive()) {
			// Lose last life and game over
			life1.gameObject.SetActive (false);
			gameOver ();
		} 
	}

	// Use this for initialization
	void Start () {
		Player.Instance.gCtrl = this;
		initialize ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void ResetBtnClick(){
		SceneManager.
		LoadScene (
			SceneManager.GetActiveScene ().name);

	}

//	private IEnumerator AddEnemy(){
//		int time = Random.Range (1, 10);
//		yield return new WaitForSeconds ((float) time);
//		Instantiate (candyCane);
//		StartCoroutine ("AddEnemy");
//	}

}
