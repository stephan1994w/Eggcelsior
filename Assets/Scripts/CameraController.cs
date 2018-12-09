using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset = new Vector3(0,5,-5);

    [Range(0.01f,1.0f)]
    [SerializeField]
    private float SmoothFactor = 1f;
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = player.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}
}
