using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWoodScript : MonoBehaviour {

	// the thickness of the member
	public bool isOneEighth = true;
	// the button that changes the wood
	private Button btn;
	// the text on the button
	private Text txt;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		txt = GetComponentInChildren<Text> ();
		btn.onClick.AddListener (TaskOnListener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// sets text to the type of wood
	public void TaskOnListener(){
		isOneEighth = !isOneEighth;
		if (isOneEighth) {
			txt.text = "Wood (1/8)";
		} else {
			txt.text = "Wood (1/16)";
		}
		
	}

	public double woodWidth(){
		if (isOneEighth)
			return 1 / 8f;
		return 1 / 16f;
	}
}
