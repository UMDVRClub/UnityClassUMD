using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (HealthManager))]
[RequireComponent (typeof (PolygonCollider2D))]

public class Enemy : MonoBehaviour {

	public Transform player;
	public float rotationDamping, MAX_MOVEMENT_SPEED, disFromTargetToStopAt;
	public Gun[] guns;

	private float currentMovementSpeed;

	private HealthManager myHealth;
	private bool canMove = true;

	void Awake(){
		myHealth = GetComponent<HealthManager> ();
	}

	void Start () {
		currentMovementSpeed = MAX_MOVEMENT_SPEED;
	}
	
	// Update is called once per frame
	void Update () {
		// get direction you want to point at
		Vector3 direction = (player.position - transform.position).normalized;

		// set vector of transform directly
		transform.up = Vector3.Lerp(transform.up, direction, rotationDamping);

		if(canMove)
			transform.position += transform.up * currentMovementSpeed * Time.deltaTime;

		currentMovementSpeed = MAX_MOVEMENT_SPEED * myHealth.GetHealthRatio ();
	}

	void FixedUpdate() {
		foreach (RaycastHit2D hit in Physics2D.RaycastAll(transform.position, transform.up)){
			if (hit.collider != null) {
				if(hit.collider.gameObject.tag.Contains("Player")){
					foreach (Gun gun in guns) {
						gun.Fire ();
					}
					break;
				}
					
			}
		}
		float distance = Vector2.Distance(transform.position, player.position);

		canMove = distance >= disFromTargetToStopAt;
	}
}
