using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementMouse : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    private GameObject basketA;
    private GameObject basketB;
    private Vector3 throwSpeed = new Vector3(-10, 10, 0);
    private Vector3 ballPos;
    public Transform ball;
    private GameObject ballGameObject;
    private CircleCollider2D circleCol;
    [HideInInspector] public bool attached =false;
    private bool thrown = false;
    private PlayerJump playerScript;
    private HandController handScript;
    private bool colBodyExit = false;
    private bool colHandExit = false;
    [HideInInspector] public string attachName;
    [HideInInspector] public int scoreTeamA = 0;
    [HideInInspector] public int scoreTeamB = 0;
    private bool colHalfExit = false;
    private bool colOutOfBoundExit = false;

    void Start()
    {
        ballGameObject = GameObject.Find("basketball");
        circleCol = ballGameObject.GetComponent<CircleCollider2D>();
        ballRigidbody = ballGameObject.GetComponent<Rigidbody2D>();
        basketA = GameObject.Find("Basket_Team2");
        basketB = GameObject.Find("Basket_Team2");
        ballPos = ball.position;
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1") && ballGameObject != null)
        {
            if(attached && !thrown){
                thrown = true;
            }
            else if(attached && thrown)
            {
                ballGameObject.AddComponent<Rigidbody2D>();
                ballRigidbody = ballGameObject.GetComponent<Rigidbody2D>();
                ballRigidbody.collisionDetectionMode = (CollisionDetectionMode2D)1;
                throwSpeed.x = (basketA.transform.position.x - ballGameObject.transform.position.x) / 2;
                throwSpeed.y = basketA.transform.position.y + 8f;
                throwSpeed.z = 0;
                ballRigidbody.AddForce(throwSpeed, ForceMode2D.Impulse);
                thrown = true;
            }
        }

        if (ballGameObject != null && colOutOfBoundExit)
        {
            ballGameObject.transform.position = ballPos;
            colOutOfBoundExit = false;
        }
        if (colBodyExit && thrown)
        {
            attached = false;
            attachName = "";
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
            colBodyExit = false;
            colHalfExit = false;
        }
        if (col.tag == "Body")
        {
            colBodyExit = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Body")
        {
            Debug.Log("collision Body exit");
            colBodyExit = true;
        }
        if (col.tag == "Half")
        {
            colHalfExit = true;
        }
        if (col.tag == "BasketA")
        {
            if (colHalfExit)
            {
                scoreTeamB = scoreTeamB + 3;
            }
            else
            {
                scoreTeamB = scoreTeamB + 2;
            }
        }
        if (col.tag == "BasketB")
        {
            if (colHalfExit)
            {
                scoreTeamA = scoreTeamA + 3;
            }
            else
            {
                scoreTeamA = scoreTeamA + 2;
            }
        }
        if (col.tag == "OutOfBound")
        {
            colOutOfBoundExit = true;
        }
    }
}
