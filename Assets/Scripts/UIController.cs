/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: UIController
 * Description: This class maintains the user interface, including
 * 		labels, buttons, scores and lives left.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	//Images that represent the lives left for the user
	[SerializeField]
	Image life1;
	[SerializeField]
	Image life2;
	[SerializeField]
	Image life3;
	//Label that shows the current score 
	[SerializeField]
	Text scoreLabel;
	//Label that shows up when the player loses all of their lives (game over)
	[SerializeField]
	Text gameOverLabel;
	//Button to start or restart the game
	[SerializeField]
	Button playBtn;



	private void initialize(){

		Player.Instance.Score = 0;

		gameOverLabel.gameObject.SetActive (false);
		// Show the button at the beginning so the user can start the game
		playBtn.gameObject.SetActive (true);

		life1.gameObject.SetActive (true);
		life2.gameObject.SetActive (true);
		life3.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
	}

	public void gameOver(){
		gameOverLabel.gameObject.SetActive (true);
		playBtn.gameObject.SetActive (true);

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
}
