using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField]
    private float MomentumIncrease = 10;
    [SerializeField]
    private float FORCE = 100f;
    public int health = 100;
    [SerializeField]
    float FlickIntervalInSeconds = 5f;
    Rigidbody rb;
    float timeOfLastFlick = 0.0f;
    [SerializeField]
    private GameObject splatPrefab;
    private bool splat = false;
    private const float SPLAT_FORCE = 20.0f;
    private List<GameObject> yokes = new List<GameObject>();
    private List<Transform> winColliders;
    public bool gameWon = false;
    public bool accelEnabled = true;

    public void Init(List<Transform> winColliders)
    {
        this.winColliders = winColliders;
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Up(float multiplier)
    {
        FlickEgg(rb, new Vector3(0, FORCE / 2, FORCE / 2 * multiplier));
    }

    public void Down()
    {
        //Do Nothing
    }

    public void Left(float multiplier)
    {
        FlickEgg(rb, new Vector3(-FORCE * multiplier, 0, 0));
    }

    public void Right(float multiplier)
    {
        FlickEgg(rb, new Vector3(FORCE * multiplier, 0, 0));
    }

    private void FlickEgg(Rigidbody rb, Vector3 forceDirection)
    {
        var currentTime = Time.time;
        var timeSinceLastFlick = currentTime - timeOfLastFlick;
        if (timeSinceLastFlick > FlickIntervalInSeconds || timeOfLastFlick==0.0f)
        {
            rb.AddForce(forceDirection);
            timeOfLastFlick = currentTime;
        }
    }

    void FixedUpdate()
    {
        //Left
        if (Input.GetKeyUp(KeyCode.A))
            Left(1);
        //Right
        if (Input.GetKeyUp(KeyCode.D))
            Right(1);
        //Up
        if (Input.GetKeyUp(KeyCode.W))
            Up(1);
    }

    private void Win()
    {
        Debug.Log("You win!!!!!!!!!!");
        gameWon = true;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var winTransform in winColliders)
        {
            if (collision.collider.transform == winTransform)
            {
                Win();
                return;
            }
        }   
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
            for (int i = 0; i < 5; i++)
            {
                var splat = Instantiate(splatPrefab, transform.position, transform.rotation);
                var splatRb = splat.GetComponent<Rigidbody>();
                splatRb.AddForce(50, 50, 50);
                yokes.Add(splat);
            }
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        //TODO: Delete the yokes but for now they're cool to leave
        splat = false;
        gameWon = false;
        transform.position = new Vector3(0,6,4);
        transform.rotation = new Quaternion(0, 0, 0, 1);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        health = 100;
        gameObject.SetActive(true);
    }
}