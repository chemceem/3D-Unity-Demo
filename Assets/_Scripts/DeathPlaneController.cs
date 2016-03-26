using UnityEngine;
using System.Collections;

public class DeathPlaneController : MonoBehaviour {

	//public instance variables
	public Vector3 spawnPoint;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		spawnPoint = new Vector3 (0f, 1f, -25f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Player")) {		
			Transform playerTransform = other.gameObject.GetComponent<Transform> ();
			playerTransform.position = this.spawnPoint;
			gameController.LivesValue--;
		} else {
			Destroy (other.gameObject);
		}
	}
}
