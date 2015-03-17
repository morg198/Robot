using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {


	public float powerLevel;
	public int rotation;
	// Use this for initialization
	void Start () {
	
	}

	public void TestPower()
	{
		if (powerLevel > 100)
			powerLevel = 100;
		
		if (powerLevel < 0)
			powerLevel = 0;
	}
	// Update is called once per frame
	void Update () {
		if (rotation > 90)
			rotation = 90;
		if (rotation < -90)
			rotation = -90;
	}
}
