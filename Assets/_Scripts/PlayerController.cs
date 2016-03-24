using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public Transform flashPoint;
	public GameObject muzzleFlash;
	public GameObject bulletImpact;

	//PRIVATE INSTANCE VARIABLES 
	private Transform _transform;

	// Use this for initialization
	void Start () {
		this._transform = this.gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	} //end update

	void FixedUpdate(){
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate (this.muzzleFlash, flashPoint.position, Quaternion.identity);

			RaycastHit hit; // used to store information from the casted ray

			if(Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f)){
				Instantiate (this.muzzleFlash, hit.point, Quaternion.identity);
			}
		}
	}//end fixedupdate
}
