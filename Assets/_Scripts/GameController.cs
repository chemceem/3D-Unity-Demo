using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Game Controller Class
 * @author : Chemcee Cherian , 300793352
 * Created on : 25-03-2016
 * Last modified : 25-03-2016 
 * Description : Class that controls the game viz. points earned, lives left etc
 * */
public class GameController : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private int _scoreValue;
	private int _lifeValues;
	private Vector3 _playerSpawnPoint;

	//PUBLIC INSTANCE VARIABLES
	public Text LivesText;
	public Text ScoreText;
	public Text GameoverText;
	public Text TimeLabel;
	public Text HighScoreText;
	public Button RestartButton;
	public GameObject player;
	public float timerValue = 22f;	//each round of the game will last for 25 seconds
	public bool isFire = true;

	//PUBLIC ACCESS METHODS
	public int ScoreValue{
		get { 
			return _scoreValue;
		}
		set { 
			this._scoreValue = value;
			if (this._scoreValue >= 2000) {
				this.finishGame ();
			} else {
				this.ScoreText.text = "SCORE : " + this._scoreValue;
			}

		}
	}

	public int LivesValue {
		get { 
			return _lifeValues;
		}
		set{
			this._lifeValues = value;
			if (this._lifeValues <= 0) {
				this._endGame ();
			} else {
				this.LivesText.text = "LIVES  : " + this._lifeValues;
			}
		}
	}

	// Use this for initialization
	void Start () {
		this._initialize ();
		Instantiate (this.player, this._playerSpawnPoint, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		this.timer();
	}

	//PRIVATE METHODS
	//INITIALIZE METHOD
	private void _initialize(){
		this._playerSpawnPoint = new Vector3 (0f, 1f, -25f);
		this.ScoreValue = 0;
		this.LivesValue = 5;
		this.GameoverText.enabled = false;
		this.HighScoreText.enabled = false;
		this.RestartButton.gameObject.SetActive(false);
	}

	//THIS METHOD IS CALLED WHEN THE PLAYER HAS LOST ALL HIS LIVES
	private void _endGame(){	
		this.isFire = false;	
		this.HighScoreText.text = "HIGH SCORE : " + this._scoreValue;
		this.GameoverText.enabled = true;
		this.TimeLabel.enabled = false;
		this.ScoreText.enabled = false;
		this.HighScoreText.enabled = true;
		this.RestartButton.gameObject.SetActive(true);
		this.LivesText.enabled = false;
		this.TimeLabel.enabled = false;
	}

	//PUBLIC METHOD

	//THIS METHOD IS CALLED WHEN THE PLAYER REACHES THE FINISH POINT
	public void finishGame(){
		this.isFire = false;
		this.GameoverText.enabled = true;
		this.GameoverText.text = "YOU WON";
		this.ScoreText.enabled = false;
		this.LivesText.enabled = false;
		this.HighScoreText.text = "HIGH SCORE : " + this._scoreValue;
		this.HighScoreText.enabled = true;
		this.TimeLabel.enabled = false;
		this.RestartButton.gameObject.SetActive(true);
	}

	//CALLED WHEN THE RESTART BUTTON IS CLICKED. WILL RESTART THE GAME
	public void RestartButtonClick(){		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//countdown timer for the game.
	public void timer(){		
		this.timerValue -= Time.deltaTime;
		if (this.timerValue < 0) {
			this._endGame ();
		} else {
			this.TimeLabel.text = "TIME : " + this.timerValue;
		}
	}
}