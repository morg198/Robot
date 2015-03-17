using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MotorMovement : MonoBehaviour {

	GameObject robot;
	public Motor motorL;
	public Motor motorR;

	public Motor motorM;

	public float fullSpeed;
	public float motorIncreaseSpeed;
	public int offset;

	public Slider s1;
	public Slider s2;
	public Slider s3;

	int selectedMotor;

	enum Motors { LEFT, RIGHT, MIDDLE };

	public Text motorText;
	public Text sMotorText;
	// Use this for initialization
	void Start () {
		robot = GameObject.FindGameObjectWithTag ("Bot");
		motorM.rotation = -90;
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.P))
		{
			
			if(selectedMotor == 0)
				selectedMotor = 1;
			else if (selectedMotor == 1)
				selectedMotor = 2;
			else if(selectedMotor == 2)
				selectedMotor = 0;
		}


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

		if(Input.GetKey(KeyCode.E))
		{
			s3.value += 1;
			motorM.TestPower();
		}
		if(Input.GetKey(KeyCode.D))
		{
			s3.value -= 1;
			motorM.TestPower();
		}


		if(Input.GetKey(KeyCode.R))
		{
			if(selectedMotor == 0)
				motorL.rotation += 1;
			else if (selectedMotor == 1)
				motorR.rotation += 1;
			else if(selectedMotor == 2)
				motorM.rotation += 1;
		}
		if(Input.GetKey(KeyCode.F))
		{
			if(selectedMotor == 0)
				motorL.rotation -= 1;
			else if (selectedMotor == 1)
				motorR.rotation -= 1;
			else if(selectedMotor == 2)
				motorM.rotation -= 1;
		}


		//Up and down movement
		if (Mathf.Round(motorL.powerLevel) + Mathf.Round(motorR.powerLevel ) <= 120 && Mathf.Round(motorL.powerLevel) + Mathf.Round(motorR.powerLevel ) > 30 &&  Mathf.Round(motorM.powerLevel) == 100)
		{
			if(motorL.rotation == -90 && motorR.rotation == -90 && motorM.rotation == -90)
			{
				float tempS2 = ((fullSpeed/2.666f) * (motorL.powerLevel/50)) +((fullSpeed/2.666f) * (motorR.powerLevel/50) + (fullSpeed/4));
				robot.transform.Translate(0, 0.5f * tempS2 * Time.deltaTime, 0);
			}
			if(motorL.rotation == 90 && motorR.rotation == 90 && motorM.rotation == 90)
			{
				float tempS2 = ((fullSpeed/2.666f) * (motorL.powerLevel/50)) +((fullSpeed/2.666f) * (motorR.powerLevel/50) + (fullSpeed/4));
				robot.transform.Translate(0, -0.5f * tempS2 * Time.deltaTime, 0);
			}
		}


		//Movement
		else if (Mathf.Round(motorL.powerLevel) == Mathf.Round(motorR.powerLevel ))
		{
			float tempS2 = ((fullSpeed/2) * (motorL.powerLevel/100)) +((fullSpeed/2) * (motorR.powerLevel/100));
			robot.transform.Translate(Vector3.forward * tempS2 * Time.deltaTime);
		}
		else if(Mathf.Round(motorL.powerLevel) > Mathf.Round(motorR.powerLevel) + offset || Mathf.Round(motorL.powerLevel) > Mathf.Round(motorR.powerLevel) - offset)
		{
			float temp = fullSpeed * (motorL.powerLevel - motorR.powerLevel) / 100;
			float tempS2 = ((fullSpeed/2) * (motorL.powerLevel/100)) +((fullSpeed/2) * (motorR.powerLevel/100));

			robot.transform.Rotate(0, 1 * temp * 20 * Time.deltaTime, 0);

			robot.transform.Translate(Vector3.forward * tempS2 * Time.deltaTime);
		}
		else if(Mathf.Round(motorR.powerLevel) > Mathf.Round(motorL.powerLevel) + offset || Mathf.Round(motorR.powerLevel) > Mathf.Round(motorL.powerLevel) - offset)
		{
			float temp = fullSpeed * (motorR.powerLevel - motorL.powerLevel) / 100;
			float tempS2 = ((fullSpeed/2) * (motorL.powerLevel/100)) +((fullSpeed/2) * (motorR.powerLevel/100));

			robot.transform.Rotate(0, -1 * temp * 20 * Time.deltaTime, 0);
			
			robot.transform.Translate(Vector3.forward * tempS2 * Time.deltaTime);
		}


		if(s3.value > s1.value + s2.value)
		{
			float temp = fullSpeed * (motorM.powerLevel -(motorR.powerLevel + motorL.powerLevel)) / 100;
			//if(motorM.rotation == -90)
				robot.transform.Rotate(motorM.rotation/3 * temp * Time.deltaTime, 0, 0);
			//if(motorM.rotation == 90)
				//robot.transform.Rotate(20 * temp * Time.deltaTime, 0, 0);
		}

		//UI Code
		motorText.text = "Left Motor Power: " + motorL.powerLevel + Environment.NewLine + "Right Motor Power: " + motorR.powerLevel + Environment.NewLine + "Middle Motor Power: " + motorM.powerLevel +
			Environment.NewLine + Environment.NewLine +	"Left Motor Rotation: " + motorL.rotation + Environment.NewLine + "Right Motor Rotation: " + motorR.rotation + Environment.NewLine + "Middle Motor Rotation: " + motorM.rotation;

		if(selectedMotor == 0)
			sMotorText.text = "Selected Motor: Left";
		else if (selectedMotor == 1)
			sMotorText.text = "Selected Motor: Right";
		else if(selectedMotor == 2)
			sMotorText.text = "Selected Motor: Middle";
	}
}
