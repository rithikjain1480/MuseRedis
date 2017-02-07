using UnityEngine;
using System.Collections;

public class BlockAdd : MonoBehaviour {

	public Object myBlock ;
    public Vector3 spawnLocation = new Vector3(0,0,2);
	//private ICollection<list1> wdlist;
	//private ICollection<list2> wdlist2;


	void Start (){
		int dlina_z = Random.Range(10, 64);
		int dlina_x = Random.Range(10, 64);
//		int[] array1 = new int[dlina_x];
//		int[] array2 = new int[dlina_z];

		for (int z = 0; z < dlina_z; z=z+2) {
//			array1[z]=z;
	    CreateBlock(z); }

		for (int z = 0; z < dlina_x; z=z+2) {
//			array2[z]=z;
			CreateBlockX(z,dlina_x);}
	}
  	
	
	
	 void CreateBlock(int z) {
        spawnLocation = new Vector3(0, 0,z+2);
		GameObject temp = (GameObject)Instantiate(myBlock, spawnLocation, Quaternion.identity);
		temp.name = "Block_" + z;


    }

	void CreateBlockX(int x, int dlina_z) {
		spawnLocation = new Vector3(x+2, 0, dlina_z);
		GameObject temp = (GameObject)Instantiate(myBlock, spawnLocation, Quaternion.identity);
		temp.name = "Block_" + x;
	}

}
