using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpHeight = 2.0f;    
    private Rigidbody2D rigidBody2D;
    private GameObject ballGameObject;
    private BallMovementMouse ballScript;
    private Vector3 jumpCoordinates;
    private float jumpDistance;
    public bool teamAJump = false;
    public bool teamBJump = false;
    private float screenWidth;
    public SinglePlayerController singlePlayerController;
    public Vector3 jump;
    private bool isGrounded;

    //private HingeJoint2D hingeJoint;

    private void Start()
    {
        screenWidth = Screen.width;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rigidBody2D = GetComponent<Rigidbody2D>();        
        initializeObjects();
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {            
            if (Input.touches[i].position.x < screenWidth / 2)
            {                
                if (singlePlayerController.teamAMode.Equals("human"))
                {
                    teamAJump = true;
                    GetJumpA();
                    Debug.Log("A jump by Human");
                }
                else if(singlePlayerController.teamBMode.Equals("human"))
                {
                    teamBJump = true;
                    GetJumpB();
                    Debug.Log("B jump by human");
                }

            }
            else
            {
                if (singlePlayerController.teamBMode.Equals("human"))
                {
                    teamBJump = true;
                    GetJumpB();
                    Debug.Log("B jump by Human");
                }
                else if(singlePlayerController.teamAMode.Equals("human"))
                {
                    GetJumpA();
                    teamAJump = true;
                    Debug.Log("A jump by human");
                }
            }
        }              
        if (ballGameObject == null) 
        {
            initializeObjects();
        }
    }

    public void GetJumpA()
    {
        if (this.gameObject.tag.Equals("TeamA"))
        {
            jumpCoordinates = ballGameObject.transform.position - transform.position;
            jumpCoordinates.y = 0.5f;          
            rigidBody2D.AddForce(jump * jumpHeight, ForceMode2D.Impulse);            
            isGrounded = false;
        }
    }
    public void GetJumpB()
    {
        if (this.gameObject.tag.Equals("TeamB"))
        {
            jumpCoordinates = ballGameObject.transform.position - transform.position;
            jumpCoordinates.y = 0.5f;
            rigidBody2D.AddForce(jump * jumpHeight,ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            //transform.gameObject.AddComponent<HingeJoint2D>();
            //hingeJoint = transform.gameObject.GetComponent<HingeJoint2D>();
            //Debug.Log("added");
            //hingeJoint.autoConfigureConnectedAnchor = true;
            ////hingeJoint.connectedBody = transform.gameObject.GetComponent<Rigidbody2D>();
            ////hingeJoint.connectedAnchor = new Vector3(0, 0, 0);
            //hingeJoint.useMotor = true;
            //JointMotor2D jointMotor = new JointMotor2D();
            //jointMotor.motorSpeed = 5f;
            //jointMotor.maxMotorTorque = 5f;
            //hingeJoint.motor = jointMotor;
            //hingeJoint.useLimits = true;
            //JointAngleLimits2D angleLimit = new JointAngleLimits2D();
            //angleLimit.min = -90f;
            //angleLimit.max = -160f;
            //hingeJoint.limits = angleLimit;
        }
    }
    void initializeObjects()
    {
        ballGameObject = GameObject.Find("basketball");
        ballScript = ballGameObject.GetComponent<BallMovementMouse>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
