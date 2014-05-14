using UnityEngine;
using System.Collections;

public class PositionZoom{

	private float minX;
	private float maxX;
	private float maxY;
	private float minY;

	private string direct;

	public PositionZoom(float minX,float minY,float maxX,float maxY,string direct){
		this.minX=minX;
		this.minY=minY;
		this.maxY=maxY;
		this.maxX=maxX;
		this.direct=direct;
	}

	public bool ifInTheZoom(Vector2 position){
		if(position.x>minX&&position.x<=maxX&&position.y>minY&&position.y<=maxY)
			return true;
		else
			return false;
	}

	public string getDirect(){
		return direct;
	}

}
