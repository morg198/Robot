using UnityEngine;
using System.Collections;

public class Col : MonoBehaviour {

	CapsuleCollider cCol;
	public GameObject mCol;
	// Use this for initialization
	void Start () {
		cCol = gameObject.GetComponent<CapsuleCollider> ();
	}


	void OnCollisionEnter(Collision col)
	{
		if(col.collider == mCol.GetComponent<BoxCollider>())
		{
			Debug.Log("Collision");
			mCol.transform.Translate(Vector3.forward  * Time.deltaTime);
			//Destroy(mCol);
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
