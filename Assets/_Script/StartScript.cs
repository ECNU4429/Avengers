using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public int timeLength = 10;
	public int nextLevel;

	public static Player[] players;

	private float myTime = 0;
	private KeyControl keyControl;
	private KeyControl keyControl2;

	// Use this for initialization
	void Start () {
		players = new Player[2];
		
	}
	
	// Update is called once per frame
	void Update () {
		myTime = myTime+1;
		print(myTime);
		if(myTime>timeLength){
			print("success");
			keyControl=new KeyControl(KeyCode.UpArrow,KeyCode.DownArrow,"Horizontal");
			players[0]=new Player("hero_spiderman",1,new Vector2(0,0),keyControl);
			keyControl2=new KeyControl(KeyCode.W,KeyCode.S,"Horizontal2");
			players[1]=new Player("hero_batman",2,new Vector2(0,0.01f),keyControl2);
			
			Application.LoadLevel(nextLevel);
		}
	}
}
