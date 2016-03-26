using UnityEngine;
using System.Collections;

/*
 * @author : Chemcee Cherian , 300793352 
 * Last modified : 25-03-2016  
 * */
public class PlayerShooting : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public Transform flashPoint;
	public GameObject muzzleFlash;
	public GameObject bulletImpact;
	public GameObject explosion;

	//PRIVATE INSTANCE VARIABLES 
	private Transform _transform;
	private GameController _gameController;

	// Use this for initialization
	void Start () {
		this._transform = this.gameObject.GetComponent<Transform> ();
		this._gameController = GameObject.FindWithTag ("GameController").GetComponent("GameController") as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		
	} //end update

	void FixedUpdate(){
		if (Input.GetButtonDown ("Fire1") && this._gameController.isFire) {
			Instantiate (this.muzzleFlash, flashPoint.position, Quaternion.identity);

			RaycastHit hit; // used to store information from the casted ray

			if(Physics.Raycast(this._transform.position, this._transform.forward, out hit, 100f)){
				
				if (hit.transform.gameObject.CompareTag ("barrel")) {
					Instantiate (this.explosion, hit.point, Quaternion.identity);
					Destroy (hit.transform.gameObject);
					this._gameController.ScoreValue += 100;
				} else {
					Instantiate (this.bulletImpact, hit.point, Quaternion.identity);
				}
			}
		}
	}//end fixedupdate
}
