using UnityEngine;
using System.Collections;

public class KeyControl{
	public KeyControl(KeyCode jump,KeyCode slid,string axeName){
		this.jump=jump;
		this.axeName=axeName;
		this.slid=slid;
	}

	public KeyCode getJump(){
		return this.jump;
	}

	public string getAxeName(){
		return this.axeName;
	}

	public KeyCode getSlid(){
		return this.slid;
	}


	private KeyCode jump;
	private KeyCode slid;
	private string axeName;
}
 
