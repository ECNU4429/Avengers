using UnityEngine;
using System.Collections;

public class KeyControl{
	public KeyControl(KeyCode jump,string axeName){
		this.jump=jump;
		this.axeName=axeName;
	}

	public KeyCode getJump(){
		return this.jump;
	}

	public string getAxeName(){
		return this.axeName;
	}


	private KeyCode jump;
	private string axeName;
}
 
