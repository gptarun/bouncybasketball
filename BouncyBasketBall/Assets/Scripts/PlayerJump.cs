using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpHeight = 40f;
    private bool isJumping = false; 
    private Rigidbody2D rigidBody2D;
    private GameObject ball;
    private Vector3 jumpCoordinates;
    private float jumpDistance;
    private HingeJoint2D hingeJoint;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("basketball") ;
    }   
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isJumping) 
        {
            Destroy(hingeJoint);
            jumpCoordinates = ball.transform.position - transform.position ;
            //jumpDistance = Vector3.Distance(ball.transform.position, transform.position);
            //jumpCoordinates.x = jumpDistance;
            jumpCoordinates.y = 5;
            rigidBody2D.AddForce(jumpCoordinates * jumpHeight);
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground") 
        {
            //transform.rotation();

            transform.gameObject.AddComponent<HingeJoint2D>();
            hingeJoint = transform.gameObject.GetComponent<HingeJoint2D>();
            //hingeJoint.autoConfigureConnectedAnchor = false;
            //hingeJoint.connectedBody = transform.gameObject.GetComponent<Rigidbody2D>();
            //hingeJoint.connectedAnchor = new Vector3(0, 0, 0);
            //hingeJoint.useMotor = true;
            //JointMotor2D jointMotor = new JointMotor2D() ;
            //jointMotor.motorSpeed = 5f;
            //jointMotor.maxMotorTorque = 5f;
            //hingeJoint.motor = jointMotor;
            //hingeJoint.useLimits = true;
            //JointAngleLimits2D angleLimit = new JointAngleLimits2D();
            //angleLimit.min = 0;
            //angleLimit.max = 90;
            //hingeJoint.limits = angleLimit;
            isJumping = false;


        }
    }
}
