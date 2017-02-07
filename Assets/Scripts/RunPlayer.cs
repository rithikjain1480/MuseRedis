using UnityEngine;
using System.Collections;

public class RunPlayer : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f, 0f,5f * Time.deltaTime );
	//transform.Translate(0f, 0f, 5f * Time.deltaTime );
		//transform.Translate(Vector3.forward * 5f * Time.deltaTime );
		//transform.Translate(Vector3.forward.x * Time.deltaTime * 5f, 0, Vector3.forward.z * Time.deltaTime * 5f);
			if (Input.GetKeyDown("1")){
		transform.Rotate(0f,(90f * Time.deltaTime), 0f );
		}
		
		
	}
}
