using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;//control the hero's face side
	[HideInInspector]
	public bool jump = false;//judge if the hero is jumping
	public bool slid = false;//judge if the hero is sliding
	public bool firstJump=false;
	public bool secondJump = false;
	public float jumpForce=300f;
	public float secondJumpForce=100f;
	public float slidForce=50f;
	public int slidTimeLength = 1; //最大滑动时间
	private float countTime = 0; //计时

	public AudioClip[] jumpClips;

	private bool grounded = false;//judge if the here is on the ground
	private Transform groundCheck;

	private bool passThrough = false;//判断玩家是否正在滑动通过隧道
	private Transform topCheck;

	public float moveForce = 365f; //force to add to the hero
	public float maxSpeed = 5f; //set the fastest speed the hero can have
	private Animator anim;

	private KeyControl keyControl;


	
	void Awake () {
		for(int i=0;i<StartScript.players.Length;i++){
			print(StartScript.players.Length);
			if(StartScript.players[i].getPlayername()+"(Clone)"==this.name)
				keyControl=StartScript.players[i].getKeyControl();
		}
		anim = GetComponent<Animator>();
		anim.SetBool("inTunnel",false);
		anim.SetBool("timeUp",false);
		groundCheck = transform.Find("groundCheck");
		topCheck = transform.Find("topCheck");

	}

	void Update(){
		grounded = Physics2D.Linecast(transform.position,groundCheck.position,1<<LayerMask.NameToLayer("ground"));
		//aDebug.DrawLine(transform.position,groundCheck.position,Color.red,1f);
		if(slid==true||passThrough==true){
			passThrough = Physics2D.Linecast(transform.position,topCheck.position,1<<LayerMask.NameToLayer("top"));
			Debug.DrawLine(transform.position,topCheck.position,Color.red,1f);
		}
		//print(grounded);
		if(Input.GetKeyDown(keyControl.getJump())&&grounded){
			jump=true;
			firstJump=true;
		}
		if(Input.GetKeyDown(keyControl.getJump())&&firstJump&&!grounded)
			secondJump=true;
		if(Input.GetKeyDown(keyControl.getSlid())&&grounded){
			slid=true;
			anim.SetBool("timeUp",false);
			anim.SetBool("slid",true);
		}

		
	}

	
	
	void FixedUpdate(){
		float h = Input.GetAxis(keyControl.getAxeName());//get user input if the user prase leftarrow or rightarrow
		anim.SetFloat("Speed",Mathf.Abs(h));

		//print("speed:"+Mathf.Abs(h));

		//turn around 
		if(h>0&&!facingRight){
			Flip();
		}
		else if (h<0&&facingRight){
			Flip();
		}

		//movement 
		if(h*rigidbody2D.velocity.x<maxSpeed){
			rigidbody2D.AddForce(Vector2.right*h*moveForce);
		}

		if(Mathf.Abs(rigidbody2D.velocity.x)>maxSpeed){
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x)*maxSpeed,rigidbody2D.velocity.y);
		}

		//jump
		if(jump){
			print("jump");
			anim.SetTrigger("Jump");
			int i = Random.Range(0,jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i],transform.position);

			rigidbody2D.AddForce(new Vector2(0f,jumpForce));
			jump = false;
			firstJump = true;
		}
		if(secondJump){
			print("sejump");
			anim.SetTrigger("Jump");
			int i = Random.Range(0,jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i],transform.position);

			//先将y方向上的速度设置为0,再向上加力完成2段跳
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0f);
			rigidbody2D.AddForce(new Vector2(0f,secondJumpForce));
			secondJump = false;
			firstJump = false;
		}

		//slid
		if(slid){
			countTime++;
			print("PlayerControl:count"+countTime);
			if(countTime==slidTimeLength){
				print("PlayerControl:Time is up");
				slid=false;
				countTime=0;
				anim.SetBool("timeUp",true);
				anim.SetBool("slid",false);
			}
		}

		if(passThrough){
			anim.SetBool("inTunnel",true);
		}
		else{
			anim.SetBool("inTunnel",false);
		}

		if(slid||passThrough){
			print("slid");
			
			//rigidbody2D.velocity = new Vector2(100f,0f);
			if(facingRight)
				rigidbody2D.AddForce(new Vector2(slidForce,0f));
			else
				rigidbody2D.AddForce(new Vector2(-1*slidForce,0f));
			
			//slid=false;
		}

		//更新玩家位置
		for(int i=0;i<StartScript.players.Length;i++){
			if(StartScript.players[i].getPlayername()+"(Clone)"==this.name)
				StartScript.players[i].setPlayerposition(transform.position);
		}
	}

	void Flip(){
		
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x*=-1;
		transform.localScale=theScale;
	}
}
