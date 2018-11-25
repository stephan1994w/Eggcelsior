using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MomentumIncrease = 10;

    [SerializeField]
    private float FORCE = 100f;

    public int health = 100;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    [SerializeField]
    float FlickIntervalInSeconds = 5f;
    Rigidbody rb;
    float timeOfLastFlick = 0.0f;

    [SerializeField]
    private GameObject splatPrefab;
    private bool splat = false;
    private const float SPLAT_FORCE = 8.0f;

    GameObject[] splats;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FlickEgg(Rigidbody rb, Vector3 forceDirection)
    {
        var currentTime = Time.time;
        var timeSinceLastFlick = currentTime - timeOfLastFlick;
        if (timeSinceLastFlick > FlickIntervalInSeconds || timeOfLastFlick==0.0f)
        {
            Debug.Log("Flick" + timeSinceLastFlick);
            rb.AddForce(forceDirection);
            timeOfLastFlick = currentTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectSwipe();

        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * (1 + (MomentumIncrease/100));
        
        //Left
        if (Input.GetKeyUp(KeyCode.A))
            FlickEgg(rb, new Vector3(-FORCE, 0, 0));
        //Right
        if (Input.GetKeyUp(KeyCode.D))
            FlickEgg(rb, new Vector3(FORCE, 0, 0));
        //Up
        if (Input.GetKeyUp(KeyCode.W))
            FlickEgg(rb, new Vector3(0, FORCE*2, 0));
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
                            FlickEgg(rb, new Vector3(FORCE, 0, 0));
                            Debug.Log("Right Swipe");
                        }
                        else
                        {
                            FlickEgg(rb, new Vector3(-FORCE, 0, 0));
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            FlickEgg(rb, new Vector3(FORCE, FORCE/2, 0));
                        }
                        // Down Swipe
                        //else
                        //{   //Down swipe
                        //    health = health - 10;
                        //    Debug.Log("Down Swipe");
                        //}
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Impact force is: " + collision.impulse.magnitude);
        if (collision.impulse.magnitude > SPLAT_FORCE)
        {
            Splat();
        }
    }

    private void Splat()
    {
        if (!splat)
        {
            splat = true;
            Debug.Log("Splat!!!!!");
            for (int i = 0; i < 5; i++)
            {
                var splat = Instantiate(splatPrefab, transform.position, transform.rotation);
                var splatRb = splat.GetComponent<Rigidbody>();
                splatRb.AddForce(50, 50, 50);
            }
            gameObject.SetActive(false);
        }
    }
}