using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimulateButtonScript : MonoBehaviour {

	public GameObject weight;
	public Button btn;
	public SimulationScript[] allSegments;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnListener);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnListener(){
		
		allSegments = FindObjectsOfType<SimulationScript> ();
		if (allSegments.Length == 0)
			return;



		//========BROKEN :(===========//
		GameObject max = allSegments [0].gameObject; //errors if no segments

		for (int i = 0; i < allSegments.Length; i++) {
			
			if (getHighestY(max) < getHighestY (allSegments [i].gameObject)) {
				max = allSegments [i].gameObject;
			}
		


			allSegments [i].b_simulating = !allSegments [i].b_simulating;
		}

		Debug.Log (max);

		//create weight yeah;

	}


	double getHighestY(GameObject obj)
	{
		float angle =  obj.transform.eulerAngles.z;
		return Mathf.Abs(
				(obj.transform.localScale.x - 0.03f)/0.02f*Mathf.Sin(angle)/2f
			) + obj.transform.position.y;
	}
}
