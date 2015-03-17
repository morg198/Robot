using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour {
	
	// Use this for initialization
	public void NextLevelButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}

	public void toggle(GameObject obj)
	{
		obj.SetActive(!obj.activeInHierarchy);
	}
}
