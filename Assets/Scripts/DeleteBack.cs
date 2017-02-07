using UnityEngine;
using System.Collections;

public class DeleteBack : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//DestroyObject(gameObject);
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
//			MainCamera.gameObject.GetComponent<Stats>().coins+=payment;
			Destroy(transform.parent.gameObject, 1f);}}
}
