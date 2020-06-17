using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour {
    [SerializeField] float scrollRate = 1.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
	}
}