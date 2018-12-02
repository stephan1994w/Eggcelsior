using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    [SerializeField]
    private Egg egg;

    public void FixedUpdate()
    {
        //Swipe Detection
        DetectSwipe();

        //Accelerometer Detection
        if(egg.accelEnabled)
        {
            Vector3 acc = Input.acceleration;
            egg.GetComponent<Rigidbody>().AddForce(acc.x * 20f, 0, 0);
        }

        //Left
        if (Input.GetKeyUp(KeyCode.A))
            egg.Left(1);
        //Right
        if (Input.GetKeyUp(KeyCode.D))
            egg.Right(1);
        //Up
        if (Input.GetKeyUp(KeyCode.W))
            egg.Up(1);
    }
    void DetectSwipe()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {
                            egg.Right(1);
                            //Debug.Log("Right Swipe");
                        }
                        else
                        {
                            egg.Left(1);
                            //Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            egg.Up(1.5f);
                        }
                        else
                        {   //Down swipe
                            egg.Down();
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    //Debug.Log("Tap");
                }
            }
        }
    }
}
