﻿using UnityEngine;
using System.Collections;

public class SegmentPlacingScript : MonoBehaviour {

	public GameObject segmentPrefab;
	private Vector3 startDragPosition;
	private bool draging = false;

	private GameObject segment = null;
	public bool isAddingMode = true;

	public LayerMask rayCastMask;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isAddingMode) {
			if (draging) {
				DisplayMember ();
			}
		} else {
			//nothing :D
		}
	}

	void DisplayMember()
	{

		Vector3 mousePositionOnWord = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		//angle
		float dy = mousePositionOnWord.y - startDragPosition.y;
		float dx = mousePositionOnWord.x - startDragPosition.x;

		float angy = dx ==0? (dy >0? 90: 270): Mathf.Atan (dy / dx);
		if (angy < 0) {
			angy =angy + Mathf.PI;
		}
		if (dy < 0) {
			angy = angy + Mathf.PI;
		}
		angy *= Mathf.Rad2Deg;
		Vector3 angry = new Vector3 (
			segment.transform.eulerAngles.x,
			segment.transform.eulerAngles.y,
			angy
		);
		segment.transform.eulerAngles = angry;


		//length of segement
		segment.transform.localScale = new Vector3 (
			Vector2.Distance(
				new Vector2(mousePositionOnWord.x, mousePositionOnWord.y),
				new Vector2 (startDragPosition.x, startDragPosition.y)
			)*0.2f + 0.03f,
			segment.transform.localScale.y,
			segment.transform.localScale.z
		);


		//center of segment
		segment.transform.position = new Vector3 (
			((mousePositionOnWord.x + startDragPosition.x)/2),
			((mousePositionOnWord.y + startDragPosition.y)/2),
			((mousePositionOnWord.z + startDragPosition.z)/2)
		);
	}

	void OnMouseDown()
	{
		if (!isAddingMode) {
			FixedJoint2D[] allSegments = FindObjectsOfType<FixedJoint2D> ();


			for (int i = 0; i < allSegments.Length; i++) {
				if (allSegments [i].connectedBody.Equals (this.gameObject)) {
					Destroy (allSegments [i]);
				}
			
			}
			Destroy (this.gameObject);
			return;
		}
		if (!draging) {
			segment = Instantiate (segmentPrefab);
			Vector3 mousePositionOnWord = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			segment.transform.position = new Vector3 (
				mousePositionOnWord.x,
				mousePositionOnWord.y,
				this.gameObject.transform.position.z
			);
			startDragPosition = segment.transform.position;
			draging = true;
		} 

	}
	void OnMouseUp(){
		if (!isAddingMode)
			return;


		draging = false;

		//fix it to the other one
		FixedJoint2D j = segment.GetComponent<FixedJoint2D> ();
		j.connectedBody = this.GetComponent<Rigidbody2D> ();


		//=========BROKEN===========//
//
//		//fix it to what it landed on
//		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, rayCastMask);
//
//		if(hit.collider != null)
//		{
//			
//			if(hit.collider.gameObject.tag.Equals("draggable") && !hit.collider.gameObject.Equals(segment))
//			{
//				Debug.Log (hit.collider.gameObject.name);
//				FixedJoint2D segementsNew = segment.AddComponent<FixedJoint2D> ();
//				segementsNew.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
//			}
//		}
//
//		segment.layer = 0;
	}

}
