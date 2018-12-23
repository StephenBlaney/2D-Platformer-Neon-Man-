﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManger levelManger;


	// Use this for initialization
	void Start () {
		levelManger = FindObjectOfType <LevelManger> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			levelManger.RespawnPlayer ();


		}

	}
}
