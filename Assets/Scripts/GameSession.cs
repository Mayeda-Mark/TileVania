using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour {
	[SerializeField] int playerLives = 3;
	[SerializeField] Text scoreText;
	int playerScore = 0;
	private void Awake() {
		int numGameSessions = FindObjectsOfType<GameSession>().Length;
		if(numGameSessions > 1) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}
	void Start () {
		// scoreText.text = playerScore.ToString();
	}
	public void ProcessPlayerDeath() {
		if(playerLives > 1) {
			TakeLife();
		} else {
			ResetGameSession();
		}
	}
	private void ResetGameSession() {
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}
	private void TakeLife() {
		playerLives--;
		FindObjectOfType<LivesDisplay>().UpdateDisplay(playerLives);
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
	public void GainPoints(int points) {
		playerScore += points;
		FindObjectOfType<ScoreDisplay>().UpdateDisplay(playerScore);
	}
	public int GetPlayerLives() { return playerLives; }
	public int GetScore() { return playerScore; }
}
