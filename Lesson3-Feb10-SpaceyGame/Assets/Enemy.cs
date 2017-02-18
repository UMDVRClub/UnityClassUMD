using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform player;

	public Gun[] guns;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// get direction you want to point at
		Vector3 direction = (player.position - transform.position).normalized;

		// set vector of transform directly
		transform.up = direction;

		// fire
		if (Input.GetMouseButton (0)) {
			//create bullet
			foreach (Gun gun in guns) {
				gun.Fire ();
			}
		}
	}
}
