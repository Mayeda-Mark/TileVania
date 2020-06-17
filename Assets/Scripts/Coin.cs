using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	[SerializeField] AudioClip coinPickup;
	[SerializeField] int coinValue = 10;
	void OnTriggerEnter2D(Collider2D collision) {
		AudioSource.PlayClipAtPoint(coinPickup, Camera.main.transform.position);
		Destroy(gameObject);
		FindObjectOfType<GameSession>().GainPoints(coinValue);
	}
}
