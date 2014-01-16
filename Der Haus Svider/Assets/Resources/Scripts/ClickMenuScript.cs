using UnityEngine;
using System.Collections;

public class ClickMenuScript : MonoBehaviour {

	void Update()
	{
		if (Input.GetKeyUp (KeyCode.UpArrow))
		{
			PlayerPrefs.SetInt ("CurrentMileStone", PlayerPrefs.GetInt ("CurrentMileStone", 0) + 1);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow))
		{
			PlayerPrefs.SetInt ("CurrentMileStone", PlayerPrefs.GetInt ("CurrentMileStone", 0) - 1);
		}
		Debug.Log ("CM:" + PlayerPrefs.GetInt ("CurrentMileStone", 0));
	}
}
