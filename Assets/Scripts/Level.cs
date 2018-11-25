using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField]
    private Egg egg;

    [SerializeField]
    private List<Transform> winColliders;

    [SerializeField]
    private UITextScript textScript;




	// Use this for initialization
	void Start () {
        egg.Init(winColliders);
        textScript.Init(egg);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
