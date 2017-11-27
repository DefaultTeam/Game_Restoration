using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenger : MonoBehaviour {

	public GameObject settingPanel;
	public GameObject playPanel;
	public GameObject exitPanel;

	public void Play()
	{
		playPanel.SetActive(!playPanel.activeSelf);
		//settingPanel.SetActive(false);
		//exitPanel.SetActive(false);
	}

	public void Settings()
	{
		settingPanel.SetActive(!settingPanel.activeSelf);
		//playPanel.SetActive(false);
		//exitPanel.SetActive(false);
	}

	public void Exit()
	{
		exitPanel.SetActive(!exitPanel.activeSelf);
		//playPanel.SetActive(false);
		//settingPanel.SetActive(false);
	}	

	public void Continue()
	{

	}

	public void NewGame()
	{
		Application.LoadLevel(1);
	}

	public void ExitYes()
	{
		Application.Quit();
	}

	public void ExitNo()
	{
		exitPanel.SetActive(false);
	}	
}
