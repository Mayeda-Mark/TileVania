using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {
	Text LivesText;
	// Use this for initialization
	void Start () {
		LivesText = GetComponent<Text>();
		UpdateDisplay(FindObjectOfType<GameSession>().GetPlayerLives());
	}
	public void UpdateDisplay(int lives) {
		LivesText.text = lives.ToString();
	}
}
