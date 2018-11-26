using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextScript : MonoBehaviour {

    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text accelText;

    [SerializeField]
    private Button resetButton;
    [SerializeField]
    private Button accelButton;

    [SerializeField]
    private Image LevelCompletePanel;
    
    [SerializeField]
    private Button restartButton;

    private Egg egg;

    // Use this for initialization

    public void Init(Egg egg)
    {
        this.egg = egg;
    }
	void Start ()
    {
        LevelCompletePanel.gameObject.SetActive(false);
        resetButton.onClick.AddListener(ResetPlayer);
        accelButton.onClick.AddListener(toggleAccelerometer);
        restartButton.onClick.AddListener(RestartPlayer);
        restartButton.onClick.AddListener(RestartPlayer);
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = "Health: " + egg.health;
        speedText.text = "Speed: " + System.Math.Round(egg.GetComponent<Rigidbody>().velocity.magnitude, 0);
        accelText.text = "Accelerometer: " + egg.accelEnabled;

        if (egg.gameWon)
        {
           LevelComplete();
        }
    }

    void ResetPlayer()
    {
        egg.Reset();
    }

    void RestartPlayer()
    {
        LevelCompletePanel.gameObject.SetActive(false);
        egg.Reset();
    }

    void LevelComplete()
    {
        LevelCompletePanel.gameObject.SetActive(true);
    }

    void toggleAccelerometer()
    {
        egg.accelEnabled = !egg.accelEnabled;
    }
}


