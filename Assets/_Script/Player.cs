using UnityEngine;
using System.Collections;

public class Player {
	public Player(string player_name,int rank,Vector2 player_pos,KeyControl keyControl){
		this.player_name=player_name;
		this.rank=rank;
		this.player_pos=player_pos;
		this.keyControl=keyControl;

	}

	public void setPlayername(string player_name){
		this.player_name=player_name;
	}

	public string getPlayername(){
		return this.player_name;
	}

	public void setRank(int rank){
		this.rank=rank;
	}

	public int getRank(){
		return this.rank;
	}

	public void setPlayerposition(Vector2 player_pos){
		this.player_pos=player_pos;
	}

	public Vector2 getPlayerposition(){
		return this.player_pos;
	}

	public void setKeyControl(KeyControl keyControl){
		this.keyControl=keyControl;
	}

	public KeyControl getKeyControl(){
		return this.keyControl;
	}

	string player_name;   //角色
	int rank;             //角色当前排名
	Vector2 player_pos;
	KeyControl keyControl;
}
