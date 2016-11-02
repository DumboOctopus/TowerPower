﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWoodScript : MonoBehaviour {

	// the thickness of the member
	public float woodThickness;
	// the button that changes the wood
	private Button btn;
	// the text on the button
	private Text txt;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		txt = GetComponentInChildren<Text> ();
		btn.onClick.AddListener (TaskOnListener);
		woodThickness = 0.125f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// sets text to the type of wood
	public void TaskOnListener(){
		if (woodThickness == 0.125) {
			woodThickness = 1 / 16f;
			txt.text = "Wood (1/16)";
		} else {
			woodThickness = 0.125f;
			txt.text = "Wood (1/8)";
		}
		
	}
}