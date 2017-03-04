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

	public bool IsAlive(){
		return currentHealth > 0;
	}
		
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.name.Contains("Laser")) {
			TakeDamage (0.2f);
			//Debug.Log ("I'm hit");
		}
	}
}
