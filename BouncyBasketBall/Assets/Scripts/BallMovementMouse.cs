using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementMouse : MonoBehaviour
{
    public Rigidbody2D ball;
    public GameObject basket1;
    private Vector3 throwSpeed = new Vector3(-10, 10, 0); 
    public Vector3 ballPos; //starting ball position
    private bool thrown = false; 

    void Start()
    {
        Physics.gravity = new Vector3(0, -20, 0);
        ballPos = ball.transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && ball != null)
        {
            if (ball.IsSleeping() || !thrown)
            {
                Debug.Log("I m out");
                thrown = true;
                throwSpeed.x = (basket1.transform.position.x - ball.transform.position.x) + 2f;
                throwSpeed.y = basket1.transform.position.y + 7.2f;
                throwSpeed.z = 0;
                Debug.Log("ball: " + ball.transform.position);
                Debug.Log("throwSpeed: " + throwSpeed);
                ball.AddForce(throwSpeed, ForceMode2D.Impulse);
            }
        }

        if (ball != null && ball.transform.position.y < -6 )
        {
            Destroy(ball);
            thrown = false;
            Debug.Log("I m in");
            Instantiate(ball, ballPos, transform.rotation);
        }

        if (ball != null && Input.GetButton("Fire2") && ball.transform.position.y < -1.6)
        {
            Destroy(ball);
            thrown = false;
            Debug.Log("I m in");
            Instantiate(ball, ballPos, transform.rotation);
        }
    }
}
