using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		if (!autoPlay){	
			MoveWithMouse();
		}
		else{
			AutoPlay();
		}
	}
	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);	//Mathf.Clamp restricts var1 to be inside the var2 and var3 (both inclusive)
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
	void AutoPlay(){
		Vector3 newPaddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, 0f);
		this.transform.position = newPaddlePos;
	}
}
