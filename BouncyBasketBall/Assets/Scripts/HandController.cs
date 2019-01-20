using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private bool rotate = false;
    private bool antiRotate = false;
    public float speed = 4f;
    private float angle;
    private GameObject ballGameObject;
    private BallMovementMouse ballScript;
    private Transform handPivot;
    private int buttonCount=0;

    void Start()
    {
        initializeObjects();
        handPivot = transform.Find("handPivot");
    }

    void Update()
    {
        initializeObjects();
        if (Input.GetButtonDown("Fire1"))
        {
            rotate = true;
        }

        if (rotate)
        {
            angle = angle - 180 * Time.deltaTime * speed;
            transform.Rotate(0, 0, -180 * Time.deltaTime * speed);
            if (angle <= -180)
            {
                rotate = false;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            buttonCount++;
            if (buttonCount % 2==0)
            {
                ballScript.throwBall = true;
            }
            antiRotate = true;
            rotate = false;
        }

        if (antiRotate)
        {
            angle = angle + 180 * Time.deltaTime * speed;
            transform.Rotate(0, 0, 180 * Time.deltaTime * speed);

            if (ballScript.attached && transform.name == ballScript.attachName && ballGameObject != null)
            {
                ballGameObject.transform.position = handPivot.position + new Vector3(0, -0.24f, 0);
            }

            if (angle >= 0)
            {
                antiRotate = false;
            }
        }
    }
    void initializeObjects()
    {
        ballGameObject = GameObject.Find("basketball");
        ballScript = ballGameObject.GetComponent<BallMovementMouse>();
    }
}

