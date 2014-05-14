using UnityEngine;
using System.Collections;

public class LevelNightInitial : MonoBehaviour {
	public Rigidbody2D hero_batman;
	public Rigidbody2D hero_spiderman;
	public Rigidbody2D hero_GreenLantern;
	public Rigidbody2D hero_Hulk;
	

	public Transform[] minTran;
	public Transform[] maxTran;
	public string[] direct;
	public int amount;  //地图块的个数

	public static PositionZoom[] positionZoom;

	public Transform birth_Tran; //出生点
	
	// Use this for initialization
	void Start () {
		print("LevelNightInitial!!!!!!!!!!!!!!");
		//建立4个玩家角色的实体
		for(int i=0;i<StartScript.players.Length;i++){
			if(StartScript.players[i].getPlayername()=="hero_spiderman"){
				Rigidbody2D heroInstance = Instantiate(hero_spiderman,new Vector2(birth_Tran.position.x,birth_Tran.position.y),Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;	
			}
			if(StartScript.players[i].getPlayername()=="hero_batman"){
				Rigidbody2D heroInstance = Instantiate(hero_batman,new Vector2(birth_Tran.position.x+0.01f,birth_Tran.position.y+0.01f),Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;	
			}
			if(StartScript.players[i].getPlayername()=="hero_GreenLantern"){
				Rigidbody2D heroInstance = Instantiate(hero_GreenLantern,new Vector2(birth_Tran.position.x+0.02f,birth_Tran.position.y+0.02f),Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;	
			}
			if(StartScript.players[i].getPlayername()=="hero_Hulk"){
				Rigidbody2D heroInstance = Instantiate(hero_Hulk,new Vector2(birth_Tran.position.x+0.03f,birth_Tran.position.y+0.03f),Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;	
			}
		}

		//建立地图的分块空间
		/*if(minTran.length!=maxTran.length||maxTran.length!=direct.length){
			print("请保证地图分块空间几个参数minPos,maxPos,direct的个数一致");
			return;
		}*/
		positionZoom=new PositionZoom[amount];
		for(int i=0;i<amount;i++){
			positionZoom[i]=new PositionZoom(minTran[i].position.x,minTran[i].position.y,
				maxTran[i].position.x,maxTran[i].position.y,direct[i]);
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
