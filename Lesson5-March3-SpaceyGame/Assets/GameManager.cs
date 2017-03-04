using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Transform playerPrefab;
	public Transform enemyPrefab;

	public Text scoreText;

	private float score = 0;

	// Use this for initialization
	void Start () {
		Transform player = Instantiate (playerPrefab, Vector2.zero, Quaternion.identity) as Transform;

		for (int i = 0; i < 10; i++) {
			float x = Random.Range (-2f, 2f);
			float y = Random.Range (-2f, 2f);
			Transform enemy = Instantiate (enemyPrefab, new Vector2 (x, y), Quaternion.identity) as Transform;
			enemy.GetComponent<Enemy> ().player = player;
		}

		PlayerInput.OnPlayerDeath += OnPlayerDied;
		Enemy.OnEnemyDied += OnAnEnemyDied;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

	private void OnPlayerDied(){
		print ("Game Mager: Player died, game over!");
		//bring up game over UI
	}

	private void OnAnEnemyDied(){
		//increase score by one
		print("Game Manager: Enemy died, increase score!");
		score++;
	}
}
