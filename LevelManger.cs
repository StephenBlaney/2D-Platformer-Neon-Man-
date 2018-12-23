using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour {


	public GameObject currentCheckPoint;
	private PlayerController player;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;
	public int pointPenaltyOnDeath;
	private float gravityStore;
	private CameraController cameraCon;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		cameraCon = FindObjectOfType<CameraController> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RespawnPlayer(){

		StartCoroutine ("RespawnPlayerCo");
		
	}

	public IEnumerator RespawnPlayerCo(){

		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		cameraCon.isFollowing = false;
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn*");
		yield return new WaitForSeconds (respawnDelay);
		//player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckPoint.transform.position;
		player.enabled = true;
		cameraCon.isFollowing = true;
		player.GetComponent<Renderer> ().enabled = true;
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);

	}
}
