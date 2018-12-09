using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour 
{

	[SerializeField]
	private Button levelOneButton;
	[SerializeField]
	private Button levelTwoButton;
	[SerializeField]
	private Button levelThreeButton;

	[SerializeField]
	private int levelOneSceneIndex;
	[SerializeField]
	private int levelTwoSceneIndex;
	[SerializeField]
	private int levelThreeSceneIndex;

	void Start () 
	{
		levelOneButton.onClick.AddListener(LoadLevelOne);
		levelTwoButton.onClick.AddListener(LoadLevelTwo);
		levelThreeButton.onClick.AddListener(LoadLevelThree);		
	}
	
	void Update () 
	{
		
	}

	public void LoadLevelOne()
	{
		SceneManager.LoadScene(levelOneSceneIndex);	
	}

	public void LoadLevelTwo()
	{
		SceneManager.LoadScene(levelTwoSceneIndex);	
	}

	public void LoadLevelThree()
	{
		SceneManager.LoadScene(levelThreeSceneIndex);	
	}
}
