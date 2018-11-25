using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextScript : MonoBehaviour {

    [SerializeField]
    private Player player;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Button resetButton;

	// Use this for initialization
	void Start ()
    {
        resetButton.onClick.AddListener(ResetPlayer);
        healthText.text = "Health: " + player.health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = "Health: " + player.health;
    }

    void ResetPlayer()
    {
        player.transform.position = Vector3.zero;
        player.transform.rotation = new Quaternion(0,0,0,1);
        player.health = 100;
    }
}
