using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool HasStarted = false;

	//  initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        if (!HasStarted)
        {
            // lock the ball to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0)) {
                HasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);

           }
        }
	}

    void OnCollisionEnter2D (Collision2D collision)
    // give the ball some random variancy to prevent getting stuck on side loop
    {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        GetComponent<Rigidbody2D>().velocity += tweak;

    }

   
}
