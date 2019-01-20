using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementMouse : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    private GameObject basket1;
    private GameObject basket2;
    private Vector3 throwSpeed = new Vector3(-10, 10, 0);
    private Vector3 ballPos;
    public Transform ball;
    private GameObject ballGameObject;
    private CircleCollider2D circleCol;
    public bool attached =false;
    public bool throwBall = false;
    private PlayerJump playerScript;
    private HandController handScript;
    private bool colBodyExit = false;
    private bool colHandExit = false;
    public string attachName;

    void Start()
    {
        initializeObjects();
        basket1 = GameObject.Find("Basket_Team2");
        basket2 = GameObject.Find("Basket_Team2");
        ballPos = ball.position;
    }

    void Update()
    {
        initializeObjects();
        if (Input.GetButtonUp("Fire1") && ballGameObject != null && throwBall && attached)
        {
            ballGameObject.AddComponent<Rigidbody2D>();
            ballRigidbody = ballGameObject.GetComponent<Rigidbody2D>();
            ballRigidbody.collisionDetectionMode = (CollisionDetectionMode2D)1;
            throwSpeed.x = (basket1.transform.position.x - ballGameObject.transform.position.x)/2;
            throwSpeed.y = basket1.transform.position.y + 8f;
            throwSpeed.z = 0;
            ballRigidbody.AddForce(throwSpeed, ForceMode2D.Impulse);
            throwBall = false;
        }

        if (ballGameObject != null && ballGameObject.transform.position.y < -6 )
        {
            Destroy(ballGameObject);
            ballGameObject = createBall(ballGameObject);
        }
        if (ballGameObject != null && Input.GetButton("Fire2") && ballGameObject.transform.position.y < -1.6)
        {
            Destroy(ballGameObject);
            ballGameObject = createBall(ballGameObject);
        }
        if (colBodyExit && colHandExit)
        {
            attached = false;
            circleCol.isTrigger = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hand" && !attached)
        {
            Debug.Log("collision detected");
            circleCol.isTrigger = true;
            Destroy(ballRigidbody);
            attached = true;
            attachName = col.name;
            colHandExit = false;
            colBodyExit = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Hand")
        {
            Debug.Log("collision Hand exit");
            colHandExit = true;
        }
        if (col.tag == "Body")
        {
            Debug.Log("collision Body exit");
            colBodyExit = true;
        }
    }

    GameObject createBall(GameObject ball)
    {
        ball=Instantiate(ball, ballPos, transform.rotation);
        ball.GetComponent<CircleCollider2D>().enabled = true;
        ball.GetComponent<BallMovementMouse>().enabled = true;
        ball.name = "basketball";
        return ball;
    }

    void initializeObjects()
    {
        ballGameObject = GameObject.Find("basketball");
        ballRigidbody = ballGameObject.GetComponent<Rigidbody2D>();
        circleCol = ballGameObject.GetComponent<CircleCollider2D>();
    }
}
