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
	[SerializeField]
	Button startBtn;


	/* This method sets the status of the UI elements in the initialization of the game.*/
	private void Initialize(){
		Player.Instance.Score = 0;

		gameOverLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);

		life1.gameObject.SetActive (true);
		life2.gameObject.SetActive (true);
		life3.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
	}

	/* This method sets the status of the UI elements when the player
	 * reaches a game over status. */
	public void GameOver(){
		gameOverLabel.gameObject.SetActive (true);
		playBtn.gameObject.SetActive (true);

		life1.gameObject.SetActive (false);
		life2.gameObject.SetActive (false);
		life3.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (true);
	}

	/* This method updates the score label in the UI with an updated score. */
	public void UpdateScoreUI(){
		scoreLabel.text = "Score: " + Player.Instance.Score;
	}

	/* This method updates the life status in the UI. */
	public void UpdateLifeUI(){
		if (life3.IsActive()) {
			life3.gameObject.SetActive (false);
		} 
		else if (life2.IsActive()) {
			life2.gameObject.SetActive (false);
		} 
		else if (life1.IsActive()) {
			// Lose last life and game over
			life1.gameObject.SetActive (false);
			GameOver ();
		} 
	}

	// Use this for initialization
	void Start () {
		Player.Instance.gCtrl = this;
		Initialize ();
	}

	// Update is called once per frame
	void Update () {
	}

	/* This method starts/restarts the game when the user clicks on the play button. */
	public void PlayBtnClick(){
		SceneManager.
		LoadScene (
			SceneManager.GetActiveScene ().name);
	}

	public void StartGameClick(){
		startBtn.gameObject.SetActive (false);
		Destroy (startBtn);
	}
}
