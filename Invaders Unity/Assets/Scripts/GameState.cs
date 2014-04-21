using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public TextMesh scoreText;
	public TextMesh highScoreText;
	public TextMesh livesText;

	public GameObject playerPrefab;
	public Transform playerSpawnPoint;

	int score;

	static int highScore;
	int lives;

	// Use this for initialization
	void Start () {
		lives = 3;
		score = 0;
		highScore = 0;
		UpdateText();
		SpawnPlayer();
	}
	
	void UpdateText () {
		scoreText.text = string.Format("{0:0000}", score);
		highScoreText.text = string.Format("{0:0000}", highScore);
		livesText.text = string.Format("{0}", lives);
	}

	public void AddScore (int scoreDelta) {
		score += scoreDelta;
		highScore = Mathf.Max(highScore, score);
		UpdateText();
	}

	public void PlayerDestroyed () {
		lives--;
		UpdateText();
		if (lives > 0) {
			StartCoroutine(WaitToSpawnPlayer());
		}
	}

	IEnumerator WaitToSpawnPlayer() {
		yield return new WaitForSeconds(2.0f);
		SpawnPlayer();
	}

	void SpawnPlayer() {
		GameObject player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity) as GameObject;
		player.transform.parent = transform;
	}
}
