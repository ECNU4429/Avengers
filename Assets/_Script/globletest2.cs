using UnityEngine;
using System.Collections;

public class globletest2 : MonoBehaviour {

	public Rigidbody2D hero_batman;
	public Rigidbody2D hero_spiderman;
	
	// Use this for initialization
	void Start () {
		if(StartScript.players[0].getPlayername()=="hero_spiderman"){
			Rigidbody2D heroInstance = Instantiate(hero_spiderman,new Vector2(0,0),Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;	
		}
		if(StartScript.players[1].getPlayername()=="hero_batman"){
			Rigidbody2D heroInstance = Instantiate(hero_batman,new Vector2(3,0),Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;	
		}
		
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	
				
	}
}
