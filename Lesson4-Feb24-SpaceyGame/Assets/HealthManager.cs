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
		Destroy(gameObject);
	}

	public void TakeDamage(float dmg){
		if (dmg <= 0)
			return;
		currentHealth -= dmg;
		spriteRenderer.color = new Color (GetHealthRatio(), GetHealthRatio(), GetHealthRatio());
		foreach (SpriteRenderer childSprite in GetComponentsInChildren<SpriteRenderer> ()) {
			childSprite.color = new Color (GetHealthRatio(), GetHealthRatio(), GetHealthRatio());
		}
	}

	public float GetHealthRatio(){
		return currentHealth / START_HEALTH;
	}
		
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.name.Contains("Laser")) {
			TakeDamage (0.2f);
			Debug.Log ("I'm hit");
		}
	}
}
