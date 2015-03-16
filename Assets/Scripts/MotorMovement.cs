using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MotorMovement : MonoBehaviour {

	GameObject robot;
	public Motor motorL;
	public Motor motorR;
	public float fullSpeed;
	public float motorIncreaseSpeed;
	public int offset;

	public Slider s1;
	public Slider s2;

	public Text motorText;
	// Use this for initialization
	void Start () {
		robot = GameObject.FindGameObjectWithTag ("Bot");
	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetKey(KeyCode.Q))
		{

			s2.value += 1;
			motorR.TestPower();
		}
		if(Input.GetKey(KeyCode.A))
		{
			s2.value -= 1;

			motorR.TestPower();
		}

		if(Input.GetKey(KeyCode.W))
		{
			s1.value += 1;
			motorL.TestPower();
		}
		if(Input.GetKey(KeyCode.S))
		{
			s1.value -= 1;
			motorL.TestPower();
		}





		if (Mathf.Round(motorL.powerLevel) == Mathf.Round(motorR.powerLevel ))
		{
			float tempS2 = ((fullSpeed/2) * (motorL.powerLevel/100)) +((fullSpeed/2) * (motorR.powerLevel/100));
			Debug.Log(tempS2);
			robot.transform.Translate(Vector3.forward * tempS2 * Time.deltaTime);
		}
		else if(Mathf.Round(motorL.powerLevel) > Mathf.Round(motorR.powerLevel) + offset || Mathf.Round(motorL.powerLevel) > Mathf.Round(motorR.powerLevel) - offset)
		{
			float tempS2 = ((fullSpeed/2) * (motorL.powerLevel/100)) +((fullSpeed/2) * (motorR.powerLevel/100));
			Debug.Log(tempS2);
			robot.transform.Rotate(0, 1 * tempS2 * 9 * Time.deltaTime, 0);

			robot.transform.Translate(Vector3.forward * tempS2 * Time.deltaTime);
		}
		else if(Mathf.Round(motorR.powerLevel) > Mathf.Round(motorL.powerLevel) + offset || Mathf.Round(motorR.powerLevel) > Mathf.Round(motorL.powerLevel) - offset)
		{
			float tempS2 = ((fullSpeed/2) * (motorL.powerLevel/100)) +((fullSpeed/2) * (motorR.powerLevel/100));
			Debug.Log(tempS2);
			robot.transform.Rotate(0, -1 * tempS2 * 9 * Time.deltaTime, 0);
			
			robot.transform.Translate(Vector3.forward * tempS2 * Time.deltaTime);
		}




		//UI Code
		motorText.text = "Left Motor Power: " + motorL.powerLevel + Environment.NewLine + "Right Motor Power: " + motorR.powerLevel;

	}
}
