using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeleteButtonScript : MonoBehaviour {

	// the weight of the tower
	public GameObject weight;
	// the button that switches between delete mode and adding mode
	public Button btn;
	// an array that holds all the segments of the tower
	public SegmentPlacingScript[] allSegments;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnListener);

	}
	//switches to deleting mode
	void TaskOnListener(){

		allSegments = FindObjectsOfType<SegmentPlacingScript> ();
		if (allSegments.Length == 0)
			return;
		
		for (int i = 0; i < allSegments.Length; i++) {
			allSegments [i].isAddingMode = false;
		}

	
	}
}
