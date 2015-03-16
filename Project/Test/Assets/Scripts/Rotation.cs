using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {



	public GameObject cam;
	public GameObject robot;

	public float rotSpeed;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("Cam1");
		robot = GameObject.FindGameObjectWithTag ("Bot");
	}

	float currX;
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
		{
			cam.transform.Rotate(0, 0, 1 * rotSpeed * Time.deltaTime, Space.Self);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			cam.transform.Rotate(0, 0, -1 * rotSpeed * Time.deltaTime, Space.Self);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			cam.transform.Rotate(0,  1 * rotSpeed * Time.deltaTime, 0, Space.Self);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			cam.transform.Rotate(0, -1 * rotSpeed * Time.deltaTime, 0, Space.Self);
		}





	}
}
