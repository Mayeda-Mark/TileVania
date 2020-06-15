using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

Rigidbody2D myRigidBody;
CapsuleCollider2D myCollider;
BoxCollider2D myFeet;
[SerializeField] float moveSpeed = 1f;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<CapsuleCollider2D>();
		myFeet = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsFacingRight()) {
			myRigidBody.velocity = new Vector2(moveSpeed, 0f);
		} else {
			myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
		}
	}
	private void Move() {
		if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))){
			myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
			return;
		}
	}
	private bool IsFacingRight() {
		return transform.localScale.x > 0;
	}
	void OnTriggerExit2D(Collider2D collision) {
		transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
	}
}
