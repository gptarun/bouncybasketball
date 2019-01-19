using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private bool rotate = false;
    private bool antiRotate = false;
    public float speed = 4f;
    private float angle;
    public GameObject ball;
    private BallMovementMouse ballScript;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<GameObject>();
        ballScript = GameObject.Find("basketball").GetComponent<BallMovementMouse>();
    }

    void Update()
    {
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
            antiRotate = true;
            rotate = false;
        }
        if (antiRotate)
        {
            angle = angle + 180 * Time.deltaTime * speed;
            transform.Rotate(0, 0, 180 * Time.deltaTime * speed);

            if (ballScript.attached == true && transform.name == ballScript.attachName && ball != null)
            {
                ball.transform.position = transform.Find("handPivot").position + new Vector3(0, -0.24f, 0);
            }

            if (angle >= 0)
            {
                antiRotate = false;
            }
        }
    }
}

