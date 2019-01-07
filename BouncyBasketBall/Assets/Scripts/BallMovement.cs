using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Debug.Log("I m in update then if");
            //Check if it is left or right?
            if (touchDeltaPosition.x < 0.0f)
            {
                Debug.Log("I m in update then if then if");
                ball.transform.Translate(Vector3.left * 10 * Time.deltaTime);
            }
            else if (touchDeltaPosition.x > 0.0f)
            {
                Debug.Log("I m in update then if then else if");
                ball.transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }

        }
    }
}
