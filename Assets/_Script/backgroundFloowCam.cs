using UnityEngine;
using System.Collections;

public class backgroundFloowCam : MonoBehaviour {

	public Transform theBackground;		
	public float smoothing;						// How smooth the parallax effect should be.
	private Transform player;		// Reference to the player's transform.
	
	void Awake ()
	{
		player = GameObject.Find("defaultPlayer").transform;
	}


	void Start ()
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		string firstPlayerName="";
		for(int i=0;i<StartScript.players.Length;i++){
			//print("CameraFollow"+StartScript.players[i].getRank());
			if(StartScript.players[i].getRank()==1)
				firstPlayerName=StartScript.players[i].getPlayername();
		}
		print("CameraFollow"+firstPlayerName);
		player = GameObject.Find(firstPlayerName+"(Clone)").transform;
		

		theBackground.position = Vector3.Lerp(theBackground.position, player.position, smoothing * Time.deltaTime);
		
		
	}
}
