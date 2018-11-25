using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextScript : MonoBehaviour {

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Button resetButton;

    private Egg egg;

    // Use this for initialization

    public void Init(Egg egg)
    {
        this.egg = egg;
    }
	void Start ()
    {
        resetButton.onClick.AddListener(ResetPlayer);
        healthText.text = "Health: " + egg.health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = "Health: " + egg.health;
        if (egg.gameWon)
        {
            //Game won
        }
    }

    void ResetPlayer()
    {
        egg.Reset();
    }
}
