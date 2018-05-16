﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.05f);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void LoadSprites (){
		
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			Destroy(gameObject);
			
			if (breakableCount == 0){
				SimulateWin();
			}
		}
		else{
			LoadSprites();
		}
	}
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}