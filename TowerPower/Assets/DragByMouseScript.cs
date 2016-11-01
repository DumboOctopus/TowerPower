using UnityEngine;
using System.Collections;

public class DragByMouseScript : MonoBehaviour {

	// world point where camera is
	private Vector3 screenPoint;
	// difference between camera's poistion and gameObject's position
	private Vector3 offset;

	// called when the mouse is clicked
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}
	// when the mouse is being dragged
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

	}
}
