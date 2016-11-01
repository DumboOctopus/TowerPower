using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWeightScript : MonoBehaviour {

	// the weight of the object
	public Rigidbody2D weight;
	//slider that controls the weight
	private Slider slider;
	//the maximum
	public float scaler = 15;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		slider.onValueChanged.AddListener(onResponse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//calculates the mass of the member
	void onResponse(float f)
	{
		weight.mass = scaler * slider.value;
	}
}
