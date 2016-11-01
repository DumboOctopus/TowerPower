using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWeightScript : MonoBehaviour {

	public Rigidbody2D weight;
	private Slider slider;
	public float scaler = 15;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		slider.onValueChanged.AddListener(onResponse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onResponse(float f)
	{
		weight.mass = scaler * slider.value;
	}
}
