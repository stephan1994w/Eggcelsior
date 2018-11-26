using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;

    [Range(0.01f,1.0f)]
    [SerializeField]
    private float SmoothFactor = 0.5f;


	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 newPos = player.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}
}
