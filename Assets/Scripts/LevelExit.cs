using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {
	float exitDelay = 2;
	float slowScale = 0.25f;
	void OnTriggerEnter2D(Collider2D collision) {
		StartCoroutine("ExitLevel");
	}

	IEnumerator ExitLevel() {
		Time.timeScale = slowScale;
		yield return new WaitForSecondsRealtime(exitDelay);
		LoadNextScene();
	}
	public void LoadNextScene() {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
		Time.timeScale = 1;
	}
}
