using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	

	public int coins;
	public string caption;
	
	void OnGUI(){

		GUI.Label(new Rect(10, 32, 100, 20), caption + coins);
	}
}