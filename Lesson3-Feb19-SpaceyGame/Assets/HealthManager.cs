using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public float START_HEALTH;

	private float currentHealth;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		currentHealth = START_HEALTH;
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Die ();
		}
		//Debug.Log (gameObject.name + " has " + currentHealth + " health.");
	}

	void Die(){
		//TODO: Kill yo self

	}

	public void TakeDamage(float dmg){
		if (dmg <= 0)
			return;
		currentHealth -= dmg;
		spriteRenderer.color = new Color (currentHealth, currentHealth, currentHealth);
	}
		
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.name.Contains("Laser")) {
			TakeDamage (0.2f);
			Debug.Log ("I'm hit");
		}
	}
}
