using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float jumpPower = 30f;
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
    private readonly float jumpConstant = 5f;
    [HideInInspector] public bool rotateHand;
    private float speed = 4f;
    private float z;
    private float rotationSpeed;
    private bool rotateA;
    private bool rotateB;
    private bool antiRotate;

    //private HingeJoint2D hingeJoint;

    private void Start()
    {
        screenWidth = Screen.width;
        jump = new Vector3(0.0f, 0.5f, 0.0f);
        rigidBody2D = GetComponent<Rigidbody2D>();
        z = 0.0f;
        rotationSpeed = 400.0f;
        antiRotate = false;
        initializeObjects();
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].position.x < screenWidth / 2 && isGrounded)
            {
                if (singlePlayerController.teamAMode.Equals("human"))
                {
                    teamAJump = true;
                    GetJumpA();
                    rotateA = true;
                }
                else if (singlePlayerController.teamBMode.Equals("human"))
                {
                    teamBJump = true;
                    GetJumpB();
                    rotateB = true;
                }

            }
            else if (Input.touches[i].position.x > screenWidth / 2 && isGrounded)
            {
                if (singlePlayerController.teamBMode.Equals("human"))
                {
                    teamBJump = true;
                    GetJumpB();
                    rotateB = true;
                }
                else if (singlePlayerController.teamAMode.Equals("human"))
                {
                    GetJumpA();
                    rotateA = true;
                    teamAJump = true;
                }
            }           
        }
        if (rotateA)
        {
            RotateHandA();
        }
        if (rotateB)
        {
            RotateHandB();
        }
        if (ballGameObject == null)
        {
            initializeObjects();
        }
    }

    private void RotateHandA()
    {
        if (this.gameObject.tag.Equals("TeamA"))
        {
            if (!antiRotate)
            {
                z -= Time.deltaTime * rotationSpeed;
            }
            if (z < -180.0f)
            {
                antiRotate = true;
            }
            if (antiRotate)
            {
                z += Time.deltaTime * rotationSpeed;
            }
            this.gameObject.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, z);
            if (z >= 0)
            {
                rotateA = false;
                z = 0;
            }
        }
    }

    private void RotateHandB()
    {
        if (this.gameObject.tag.Equals("TeamB"))
        {
            if (!antiRotate)
            {
                z -= Time.deltaTime * rotationSpeed;
            }
            if (z < -180.0f)
            {
                antiRotate = true;
            }
            if (antiRotate)
            {
                z += Time.deltaTime * rotationSpeed;
            }
            this.gameObject.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, z);
            if (z >= 5)
            {
                rotateB = false;
                z = 0;
            }
        }
    }

    public void GetJumpA()
    {
        if (this.gameObject.tag.Equals("TeamA"))
        {
            jumpCoordinates = ballGameObject.transform.position - transform.position;
            jumpCoordinates.y = jumpConstant;
            rigidBody2D.AddForce(jumpCoordinates * jumpPower);
            
        }
    }
    public void GetJumpB()
    {
        if (this.gameObject.tag.Equals("TeamB"))
        {
            jumpCoordinates = ballGameObject.transform.position - transform.position;
            jumpCoordinates.y = jumpConstant;
            rigidBody2D.AddForce(jumpCoordinates * jumpPower);

        }
    }
    void initializeObjects()
    {
        ballGameObject = GameObject.Find("basketball");
        ballScript = ballGameObject.GetComponent<BallMovementMouse>();
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.gameObject.tag == "ground")
        {
            isGrounded = true;

        }
    }

    void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.collider.gameObject.tag == "ground")
        {
            isGrounded = false;

        }
    }
}