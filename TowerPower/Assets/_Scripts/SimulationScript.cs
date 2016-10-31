using UnityEngine;
using System.Collections;

public class SimulationScript : MonoBehaviour {

	public bool b_simulating = false;
	public bool b_initedSimulation = false;
	private Transform originalTransform;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (b_simulating) {
			if (!b_initedSimulation) {
				originalTransform = this.transform;
				GetComponent<Rigidbody2D> ().isKinematic = true;
				b_initedSimulation = true;
			}

		} else {
			if (b_initedSimulation) {
				if (originalTransform != null) {
					this.transform.position = originalTransform.position;
					this.transform.eulerAngles = originalTransform.eulerAngles;
					this.transform.localScale = originalTransform.localScale;
				}

				GetComponent<Rigidbody2D> ().isKinematic = false;
				b_initedSimulation = false;
			}
		
		}
	}
}
