using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour 
{

    void Awake()
    {
		// Keep this object alive throughout game
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Scene currentScene = SceneManager.GetActiveScene ();	
			string sceneName = currentScene.name;

			if (sceneName != "MainMenu")
			{
				SceneManager.LoadScene(0);
			}
		}
	}

}
