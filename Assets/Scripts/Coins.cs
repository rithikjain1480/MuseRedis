using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	public int payment;
	public float coins;
	private GameObject MainCamera;
	
	void Start(){
    GetComponent<Collider>().isTrigger = true;
	MainCamera = GameObject.Find("Main Camera");
	}
	
	void OnTriggerEnter(Collider other){
	if(other.tag == "Player"){
	MainCamera.gameObject.GetComponent<Stats>().coins+=payment;
	Destroy(gameObject);}}
}
