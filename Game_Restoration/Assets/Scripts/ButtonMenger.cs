using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenger : MonoBehaviour {

	public GameObject setting;
	public GameObject play;
	public GameObject exit;

    private bool continueEneble = true;

    public void Start()
    {

        if (Global.curentlevel <= 1)
        {
            continueEneble = false;
        }
        else
            continueEneble = true;
    }
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
        if(continueEneble)
        {
            SceneManager.LoadScene(Global.curentlevel);
        }

	}

	public void NewGame()
	{
        Global.curentlevel = 1;
        PlayerPrefs.SetInt("level", Global.curentlevel);
        SceneManager.LoadScene(1);
    }

	public void ExitYes()
	{
        PlayerPrefs.SetInt("level", Global.curentlevel);
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

