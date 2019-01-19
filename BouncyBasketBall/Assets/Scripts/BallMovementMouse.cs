using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementMouse : MonoBehaviour
{
    public Rigidbody2D ball;
    public GameObject basket1;
    private Vector3 throwSpeed = new Vector3(-10, 10, 0); 
    public Vector3 ballPos; 
    private bool thrown = false;
    private GameObject hand;
    private GameObject ballGameObject;
    private CircleCollider2D circleCol;
    private HingeJoint2D hinge;
    private Rigidbody2D rb;
    public bool attached =false;
    public string attachName;

    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        ballPos = ball.transform.position;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && ball != null)
        {
            if (attached)
            {
                //Destroy(ballGameObject.GetComponent("HingeJoint2D"));
                ballGameObject.AddComponent<Rigidbody2D>();
                Debug.Log("Added rigid body");
                attached = false;
                throwSpeed.x = (basket1.transform.position.x - ball.transform.position.x) + 2f;
                throwSpeed.y = basket1.transform.position.y + 6f;
                throwSpeed.z = 0;
                ball.AddForce(throwSpeed, ForceMode2D.Impulse);
                thrown = true;
            }
                
        }

        if (ball != null && ball.transform.position.y < -6 )
        {
            Destroy(ball);
            thrown = false;
            Instantiate(ball, ballPos, transform.rotation);
            ball.gameObject.tag = "Ball";
        }

        if (ball != null && Input.GetButton("Fire2") && ball.transform.position.y < -1.6)
        {
            Destroy(ball);
            thrown = false;
            Instantiate(ball, ballPos, transform.rotation);
            ball.gameObject.tag = "Ball";
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hand" )
        {
            Debug.Log("collision detected");
            ballGameObject = ball.transform.Find("attachBall").gameObject;
            ballGameObject.transform.position = col.gameObject.transform.Find("handPivot").position;
            attached = true;
            thrown = false;
            attachName = col.name;
            Destroy(ballGameObject.GetComponent("Rigidbody2D"));
            //Debug.Log(ballGameObject.transform.position);
            //attachBall(col);
        }
    }
    void attachBall(Collider2D col)
    {
        ballGameObject = ball.gameObject;
        ballGameObject.AddComponent<HingeJoint2D>();
        hand = col.gameObject;
        hinge = ballGameObject.GetComponent<HingeJoint2D>();
        rb = hand.GetComponent<Rigidbody2D>();
        hinge.connectedBody = rb;
        hinge.connectedAnchor = col.transform.position;
        attached = true;
    }
}
