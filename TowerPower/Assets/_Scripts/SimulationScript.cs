using UnityEngine;
using System.Collections;

public class SimulationScript : MonoBehaviour {

	// whether the app is simulating
	public bool b_simulating = false;
	// whether simulation has been initiliazed
	public bool b_initedSimulation = false;
	// the original position before the simulation
	private Vector3 originalPosition;
	private Vector3 originalEulerAngles;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (b_simulating) {
			if (!b_initedSimulation) {
				originalPosition = new Vector3 (
					this.transform.position.x,
					this.transform.position.y,
					this.transform.position.z
				);

				originalEulerAngles = new Vector3 (
					this.transform.eulerAngles.x,
					this.transform.eulerAngles.y,
					this.transform.eulerAngles.z
				);
					

				GetComponent<Rigidbody2D> ().isKinematic = false;
				b_initedSimulation = true;
			}

		} else {
			if (b_initedSimulation) {
				GetComponent<Rigidbody2D> ().isKinematic = true;
				if (originalEulerAngles != null) {
					this.transform.position = originalPosition;
					this.transform.eulerAngles = originalEulerAngles;
				}


				b_initedSimulation = false;
			}
		
		}
	}
}
