using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour {
	Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		UpdateDisplay(FindObjectOfType<GameSession>().GetScore());
	}
	public void UpdateDisplay(int score) {
		scoreText.text = score.ToString();
	}
}
