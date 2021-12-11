﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public enum ControlType { HumanInput, AI }
	public ControlType controlType = ControlType.HumanInput;
	
	public float BestLapTime { get; private set; } = Mathf.Infinity;
	
	public float LastLapTime { get; private set; } = 0;
	
	public float CurrentLapTime { get; private set; } = 0;
	
	public int CurrentLap { get; private set; } = 0;
	
	private float lapTimerTimestamp;
	private int lastCheckpointPassed = 0;
	
	private Transform checkpointsParent;
	private int checkpointCount;
	private int checkpointLayer;
	private CarController carController;
	
    void Awake()
    {
		checkpointsParent = GameObject.Find("Checkpoints").transform;
		checkpointCount = checkpointsParent.childCount;
		checkpointLayer = LayerMask.NameToLayer("Checkpoint");
		carController = GetComponent<CarController>();
    }

	void StartLap(){
		Debug.Log("Start Lap!");
		CurrentLap++;
		lastCheckpointPassed = 1;
		lapTimerTimestamp = Time.time;
	}
	
	void EndLap(){
		LastLapTime = Time.time - lapTimerTimestamp;
		BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
		Debug.Log("End Lap! Laptime was "+LastLapTime+" seconds");
	}
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.layer != checkpointLayer){
			return;
		}
		
		//If this is checkpoint 1...
		if(collider.gameObject.name == "1"){
			// ...and we've completed a lap 
			if(lastCheckpointPassed == checkpointCount){
				EndLap();
			}
			
			// If we are on our first lap or we've passed the last checkpoint - start a new lap
			if(CurrentLap == 0 || lastCheckpointPassed == checkpointCount){
				StartLap();
			}
			return;
		}
		//If we've passed the next checkpoint, the sequence, update the latest checkpoint
		if(collider.gameObject.name == (lastCheckpointPassed + 1).ToString()){
			lastCheckpointPassed++;
		}
	}
    // Update is called once per frame
    void Update()
    {
		CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0;
		
        if(controlType == ControlType.HumanInput){
			carController.Steer = GameManager.Instance.InputController.SteerInput;
			carController.Throttle = GameManager.Instance.InputController.ThrottleInput;
		}
    }
}
