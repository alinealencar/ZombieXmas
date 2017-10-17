/********************************************************************
 * COMP3064 - ZombieXmas Game
 * 
 * Class: Player
 * Description: This is a singleton class that keeps track of the score
 * 		of the game and it communicates with the UIController class.
 * 
 * Author: Aline Alencar
 ********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public UIController gCtrl;
	static private Player _instance;
	private int _score = 0;

	//Constructor
	private Player(){
	}

	//Property
	public int Score {
		get { return _score; }
		set { 
			_score = value;
			gCtrl.UpdateScoreUI();
		}

	}

	//Property
	static public Player Instance {
		get{ 
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}

	//Mr. Snowball loses a life
	public void LoseLife(){
		gCtrl.UpdateLifeUI ();
	}
}
