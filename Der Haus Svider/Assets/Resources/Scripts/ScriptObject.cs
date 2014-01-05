using UnityEngine;
using System.Collections;

public class ScriptObject : MonoBehaviour {

	GameObject ClickMenu;
	// Use this for initialization
	void Start ()
	{
		ClickMenu = (GameObject)Instantiate (Resources.Load ("Prefabs/OilSpill"));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
