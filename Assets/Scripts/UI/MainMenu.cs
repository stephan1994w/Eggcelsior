using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour 
{

	[SerializeField]
	private Button startGameButton;
	[SerializeField]
	private Button continueGameButton;
	[SerializeField]
	private Button exitGameButton;

	[SerializeField]
	private int levelSceneIndex;

	[SerializeField]
	private int continueSceneIndex;

	void Start () 
	{
		startGameButton.onClick.AddListener(StartGame);
		continueGameButton.onClick.AddListener(ContinueGame);
		exitGameButton.onClick.AddListener(ExitGame);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			//TODO: Use in another object / script
			Application.Quit();
			
		}
	}

	void FixedUpdate () {

	}

	public void StartGame()
	{
		SceneManager.LoadScene(levelSceneIndex);	
	}

	public void ContinueGame()
	{
		SceneManager.LoadScene(continueSceneIndex);	
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
