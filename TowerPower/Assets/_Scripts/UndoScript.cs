using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UndoScript : MonoBehaviour {

	private Stack<UndoableAction> undoableActionsStack;
	public static GameObject segmentPrefab;

	// Use this for initialization
	void Start () {
		undoableActionsStack = new Stack<UndoableAction> ();
		//THIS IS CANCER WAY of doing it but eehhh
		segmentPrefab = FindObjectOfType<SegmentPlacingScript> ().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void addedSegment(GameObject obj)
	{
		undoableActionsStack.Push (
			new UndoableAction (UndoableAction.ADD, obj)
		);
	}

	public void removedSegment(GameObject obj)
	{
		undoableActionsStack.Push (
			new UndoableAction (UndoableAction.REMOVE, obj)
		);
	}


	public void undo()
	{
		if (undoableActionsStack.Count > 0) {
			UndoableAction a = undoableActionsStack.Pop ();
			a.undo ();
		}
	}


	private class UndoableAction{
		public static int ADD = 0, REMOVE = 1;
		private int action;
		private Vector3 positionOfSeg;
		private Vector3 orientationOfSeg;
		private Vector3 scaleOfSeg;
		private GameObject obj;


		public UndoableAction(int type, GameObject segment)
		{
			action = type;


			positionOfSeg = segment.transform.position;
			orientationOfSeg = segment.transform.eulerAngles;
			scaleOfSeg = segment.transform.localScale;

			obj = segment;
		}

		public void undo()
		{
			if (action == ADD)
				Destroy (obj);
			else if (action == REMOVE) {
				GameObject segment = Instantiate (segmentPrefab);
				segment.transform.position = positionOfSeg;
				segment.transform.eulerAngles = orientationOfSeg;
				segment.transform.localScale = scaleOfSeg;
			}
		}

	}


}
