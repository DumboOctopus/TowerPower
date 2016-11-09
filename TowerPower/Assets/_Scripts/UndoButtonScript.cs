using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UndoButtonScript : MonoBehaviour {

	private UndoScript undoScript;

	// Use this for initialization
	void Start () {
		undoScript = Camera.main.GetComponent<UndoScript> ();
		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (onButtonPress);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onButtonPress()
	{
		undoScript.undo ();
	}
}
