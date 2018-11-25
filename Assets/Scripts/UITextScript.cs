using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextScript : MonoBehaviour {

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Button resetButton;

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
        restartButton.onClick.AddListener(RestartPlayer);
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = "Health: " + egg.health;
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
}


