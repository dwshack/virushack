﻿using UnityEngine;
using System.Collections;

public class SentryPatrol : MonoBehaviour {

	public GameObject target;
	public string patrolType = "stationary";
	public float maxSpeed = 5.0f;
	public float moveHorizontal = 0.0f;
	public float moveVertical = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (patrolType == "chase")
			this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, maxSpeed * Time.deltaTime);
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveHorizontal * maxSpeed, moveVertical * maxSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		switch (patrolType)
		{
			case "leftright":
				moveHorizontal = -moveHorizontal;
				break;

			case "updown":
				moveVertical = -moveVertical;
				break;

			case "clockwise":
				if (moveHorizontal != 0)
				{	
					moveVertical = -moveHorizontal;
					moveHorizontal = 0;
				}
				else
				{
					moveHorizontal = moveVertical;
					moveVertical = 0;
				}

				break;
		
			case "counterclockwise":
				if (moveHorizontal != 0)
				{	
					moveVertical = moveHorizontal;
					moveHorizontal = 0;
				}
				else
				{
					moveHorizontal = -moveVertical;
					moveVertical = 0;
				}
				break;

			case "stationary":
			default:
				break;

		}
	}


}
