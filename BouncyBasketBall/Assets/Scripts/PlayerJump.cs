using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpHeight = 40f;
    private bool isJumping = false; 
    private Rigidbody2D rigidBody2D;
    private GameObject ballGameObject;
    private BallMovementMouse ballScript;
    private Vector3 jumpCoordinates;
    private float jumpDistance;
    private HingeJoint2D hingeJoint;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        initializeObjects();
    }
    private void Update()
    {
        initializeObjects();
        if (Input.GetButtonDown("Fire1") && !isJumping ) 
        {
            jumpCoordinates = ballGameObject.transform.position - transform.position ;
            jumpCoordinates.y = 5;
            rigidBody2D.AddForce(jumpCoordinates * jumpHeight);
            isJumping = true;
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
            isJumping = false;
        }
    }
    void initializeObjects()
    {
        ballGameObject = GameObject.Find("basketball");
        ballScript = ballGameObject.GetComponent<BallMovementMouse>();
    }
}
