using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {

	public Motor motor;
	public Slider s;
	// Use this for initialization
	void Start () {
		s = gameObject.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		motor.powerLevel = s.value;
	}
}
