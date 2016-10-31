using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeleteButtonScript : MonoBehaviour {

	public GameObject weight;
	public Button btn;
	public SegmentPlacingScript[] allSegments;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnListener);

	}

	void TaskOnListener(){

		allSegments = FindObjectsOfType<SegmentPlacingScript> ();
		if (allSegments.Length == 0)
			return;
		
		for (int i = 0; i < allSegments.Length; i++) {
			allSegments [i].isAddingMode = false;
		}

	
	}
}
