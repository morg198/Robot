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
	int tempNum;
	float currX;
	// Update is called once per frame
	void Update () {



		if(cam.transform.eulerAngles.z < 288 && cam.transform.eulerAngles.z > 144)
		{
			tempNum = 288;
			cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, tempNum);
		}
		if(cam.transform.eulerAngles.z > 55 && cam.transform.eulerAngles.z < 144)
		{
			tempNum = 55;
			cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, tempNum);
		}

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
			cam.transform.Rotate(0,  1 * rotSpeed * Time.deltaTime, 0, Space.World);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			cam.transform.Rotate(0, -1 * rotSpeed * Time.deltaTime, 0, Space.World);
		}






	}
}
