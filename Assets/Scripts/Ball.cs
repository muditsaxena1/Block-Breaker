using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		/*Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if(hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}*/
		if (this.transform.position.y < 1f){
			float xVelocity = (float)(this.transform.position.x - paddle.transform.position.x) * 8;
			xVelocity = Mathf.Clamp(xVelocity, -8f, 8f);
			if(hasStarted){
				GetComponent<AudioSource>().Play();
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, 10f);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (!hasStarted){
			//lock ball relative to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
	
			//wait for mouse press to start
			if (Input.GetMouseButtonUp(0)){
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
		//print ("ball x velocity:" + this.rigidbody2D.velocity.x);
	}
}
