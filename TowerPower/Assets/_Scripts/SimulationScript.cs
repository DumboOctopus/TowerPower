using UnityEngine;
using System.Collections;

public class SimulationScript : MonoBehaviour {

	// whether the app is simulating
	public bool b_simulating = false;
	// whether simulation has been initiliazed
	public bool b_initedSimulation = false;
	// the original tower before the simulation
	private Transform originalTransform;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (b_simulating) {
			if (!b_initedSimulation) {
				originalTransform = this.transform;
				GetComponent<Rigidbody2D> ().isKinematic = false;
				b_initedSimulation = true;
			}

		} else {
			if (b_initedSimulation) {
				if (originalTransform != null) {
					this.transform.position = originalTransform.position;
					this.transform.eulerAngles = originalTransform.eulerAngles;
					this.transform.localScale = originalTransform.localScale;
				}

				GetComponent<Rigidbody2D> ().isKinematic = true;
				b_initedSimulation = false;
			}
		
		}
	}
}
