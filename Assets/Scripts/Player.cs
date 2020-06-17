﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//Config
	[SerializeField] float runSpeed = 8f;
	[SerializeField] float jumpSpeed = 15f;
	[SerializeField] float climbSpeed = 8f;
	float deathVertical = 25f;
	float deathHorizontal = -100f;
	//State
	bool isAlive = true;
	//Cached vars
	Rigidbody2D myRigidBody;
	Animator myAnimator;
	CapsuleCollider2D myBodyCollider;
	BoxCollider2D myFeet;
	GameSession gameSession;
	float playerGravity;
	
	void Start () {
		myFeet = GetComponent<BoxCollider2D>();
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		myBodyCollider = GetComponent<CapsuleCollider2D>();
		playerGravity = myRigidBody.gravityScale;
		gameSession = FindObjectOfType<GameSession>();
	}
	
	void Update () {
		if(!isAlive) { return; }
		Run();
		Jump();
		Climb();
		FlipSprite();
		Die();
	}
	private void Run() {
		float controlThrow = Input.GetAxis("Horizontal");
		Vector2 playerVelocity = new Vector2( controlThrow * runSpeed, myRigidBody.velocity.y);
		myRigidBody.velocity = playerVelocity;
	}

	private void Jump() {
		if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
		bool playerHasVerticalSpeed  = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
		if(Input.GetButtonDown("Jump")) {
			Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
			myRigidBody.velocity += jumpVelocity;
		}
		// myAnimator.SetBool("isJumping", playerHasVerticalSpeed);
	}
	private void Climb() {
		if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbable"))) { 
			myAnimator.SetBool("isClimbing", false);
			myRigidBody.gravityScale = playerGravity;
			return; 
		}
		myRigidBody.gravityScale = 0;
		float controlThrow = Input.GetAxis("Vertical");
		Vector2 playerVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
		myRigidBody.velocity = playerVelocity;
		bool playerHasVerticalSpeed  = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
		myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
	}
	private void FlipSprite() {
		bool playerHasHorizontalSpeed  = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed) {
			transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
		}
		myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
	}
	private void Die() {
		if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards"))){
			Vector2 DeathVelocity = new Vector2(deathHorizontal, deathVertical);
			myRigidBody.velocity = DeathVelocity;
			myAnimator.SetBool("hasDied", true);
			isAlive = false;
			gameSession.ProcessPlayerDeath();
		}
	}
}
