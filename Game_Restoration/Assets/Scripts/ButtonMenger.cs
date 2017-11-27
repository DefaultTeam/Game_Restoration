using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenger : MonoBehaviour {

	public GameObject setting;
	public GameObject play;
	public GameObject exit;

	public void Play()
	{
		play.SetActive(!play.activeSelf);
		setting.SetActive(false);
		exit.SetActive(false);
	}

	public void Settings()
	{
		setting.SetActive(!setting.activeSelf);
		play.SetActive(false);
		exit.SetActive(false);
	}

	public void Exit()
	{
		exit.SetActive(!exit.activeSelf);
		play.SetActive(false);
		setting.SetActive(false);
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
		exit.SetActive(false);
	}	

	public void SetMusic(float val)
	{
		Global.music = val;
	}

	public void SetSound(float val)
	{
		Global.sound = val;
	}
}

