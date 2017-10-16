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
			gCtrl.updateUI();
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
		gCtrl.loseLife ();
	}
}
