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

	public bool ifInTheZoom(float x,float y){
		if(x>minX&&x<=maxX&&y>minY&&y<minY)
			return true;
		else
			return false;
	}

	public string getDirect(){
		return direct;
	}

}
