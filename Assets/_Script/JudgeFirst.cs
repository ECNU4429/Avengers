using UnityEngine;
using System;
using System.Collections;




public class JudgeFirst : MonoBehaviour {

	private Player[] players;
	private PositionZoom[] positionZoom;
	private ArrayList orderedZoom; //玩家所处区域的顺序排列列表
	private Hashtable userRank; //玩家在各自所处区域的顺序
	private ArrayList playerOrder; //玩家总的顺序
	private float[] sortPosArray2;
	private int lastZoomPlayerNum; //上一个区域内玩家数量
	// Use this for initialization
	void Start () {
		players=StartScript.players;
		//print("judgefirst:playerslength"+players.Length);
		positionZoom=LevelNightInitial.positionZoom;

		orderedZoom=new ArrayList();
		userRank=new Hashtable();
		playerOrder=new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		//print("JudgeFirst:Update");
		sortPositionZoom();
		sortPlayers();
	}


	/**
	*玩家所处在的区域的顺序进行排序
	*这里必须满足最后一个区域和第一个区域有人时，最后第二个区域无人
	*/
	private void sortPositionZoom(){
		bool isInLastZoom=false; //上一个区域是否有玩家
		orderedZoom.Clear();
		for(int j=0;j<positionZoom.Length;j++){
			for(int i=0;i<players.Length;i++){
				if(positionZoom[j].ifInTheZoom(players[i].getPlayerposition())){
					if(isInLastZoom==false&&j==positionZoom.Length-1){		//如果这是地图上最后一个块，则从实际来说，应该排在末尾
						orderedZoom.Add(positionZoom[j]);
					}
					else{
						orderedZoom.Insert(0,positionZoom[j]);
					}
					isInLastZoom=true;
					break;
				}
				else{
					if(i==players.Length-1)
						isInLastZoom=false;
				}
			}
		}
		//print("JudgeFirst:orderedZoomLength"+orderedZoom.Count);
	}

	/**
	 *得出玩家之间的排名并更新排名
	 */
	private void sortPlayers(){
		IEnumerator  enumerator = orderedZoom.GetEnumerator(); 
		
		//print("judgefirst:playerslength:"+players.Length);
		float[] sortPosArray=new float[4]; //专对于x,y轴上位置进行排序
		//float[] sortPosArray2=new float[4];

		playerOrder.Clear();
		lastZoomPlayerNum=0;

		while (enumerator.MoveNext()){
			userRank.Clear();
			int count=0;
			PositionZoom currentPos=(PositionZoom)enumerator.Current;
			for(int j=0;j<players.Length;j++){
				if(currentPos.ifInTheZoom(players[j].getPlayerposition())&&
					(currentPos.getDirect().Equals("RIGHT")||currentPos.getDirect().Equals("LEFT"))){
					sortPosArray[count]=players[j].getPlayerposition().x;
					count++;
					//userRank.Add(players[j].getPlayerposition().x,players[j]);
				}
				else if(currentPos.ifInTheZoom(players[j].getPlayerposition())){              
					sortPosArray[count]=players[j].getPlayerposition().y;
					count++;
					//userRank.Add(players[j].getPlayerposition().y,players[j]);
				}
			}

			print("judgefirst:count:"+count);
			//解决数组长度带来的问题
			sortPosArray2=new float[2];
			sortPosArray2 = new float[count];
			print("sortPosArray2Length:"+sortPosArray2.Length);

			for(int a=0;a<count;a++){
				sortPosArray2[a]=sortPosArray[a];
			}

			//排序数组sortPosArray
			Array.Sort(sortPosArray2);
			

			if(currentPos.getDirect().Equals("RIGHT")){  //向右走的路径
				for(int j=0;j<players.Length;j++){
					for(int i=0;i<count;i++){
						if(players[j].getPlayerposition().x==sortPosArray2[i]){
							userRank.Add((count-i).ToString(),players[j]);
							break;
						}
					}
				}
			}
			else if(currentPos.getDirect().Equals("LEFT")){   //向左走的路径
				for(int j=0;j<players.Length;j++){
					for(int i=0;i<count;i++){
						if(players[j].getPlayerposition().x==sortPosArray2[i]){
							userRank.Add(i.ToString(),players[j]);
							break;
						}
					}
				}
			}
			else if(currentPos.getDirect().Equals("UP")){   //向上走的路径
				for(int j=0;j<players.Length;j++){
					for(int i=0;i<count;i++){
						if(players[j].getPlayerposition().y==sortPosArray2[i]){
							userRank.Add((count-i).ToString(),players[j]);
							break;
						}
					}
				}
			}
			else if(currentPos.getDirect().Equals("DOWM")){   //向下走的路径
				for(int j=0;j<players.Length;j++){
					for(int i=0;i<count;i++){
						if(players[j].getPlayerposition().y==sortPosArray2[i]){
							userRank.Add(i.ToString(),players[j]);
							break;
						}
					}
				}
			}


			//jiwofieowf检查userRank中的排序

			//print("judgefirst:userRank:"+userRank.Count);

			
			//if(currentPos.getDirect().Equals("RIGHT")||currentPos.getDirect().Equals("UP")){
				IDictionaryEnumerator enumerator1 = userRank.GetEnumerator();  
    			while (enumerator1.MoveNext())  
    			{ 
    				//print("judgefirst:userRank1:"+enumerator1.Value); 
    			    playerOrder.Add(enumerator1.Value); 
    			}  
				
			//}
			/*else{
				IDictionaryEnumerator enumerator1 = userRank.GetEnumerator();  
    			while (enumerator1.MoveNext())  
    			{  
    				//print("judgefirst:userRank2:"+(Player)enumerator1.Value); 
    			    playerOrder.Insert(lastZoomPlayerNum,(Player)enumerator1.Value); 
    			}  
			}*/

			lastZoomPlayerNum=count;

		}

		//更新玩家排名
		//print("judgefirst playerOrderSize"+playerOrder.Count);
		int rank=1;
		IEnumerator  enumerator3 = playerOrder.GetEnumerator(); 
		while (enumerator3.MoveNext()){
			Player pl=(Player) enumerator3.Current;
			//print("judgefirst rank"+rank);
			pl.setRank(rank);
			rank++;
			//print("judgefirst:"+pl.getPlayername());
			//print("judgefirst:"+ StartScript.players[0].getPlayername()+StartScript.players[0].getRank());

		}

	}

	
}
