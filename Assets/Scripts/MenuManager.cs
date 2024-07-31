using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {


	public string RateUsUrl,MoreGamesURL;
	public Text CurrentLevelText;
    [Header("Share")]
    public string Subject;
    public string Body;

    int CurrentLevel;
	

	// Use this for initialization
	void Start () {
      
            CurrentLevel = PlayerPrefs.GetInt("Level", 1);
            CurrentLevelText.text = "MISSION: " + CurrentLevel;
        
	}


	public void LoadLevel(){

		SceneManager.LoadScene ("Game");
	}


	public void RateUs ()
	{
        Application.OpenURL(RateUsUrl);

    }


    public void MoreGames(){

		Application.OpenURL (MoreGamesURL);
	}


    public void Restart()
    {

        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");

    }
    

    public void ShareClick()
    {
        StartCoroutine(StartShare());
    }

    IEnumerator StartShare()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().SetSubject(Subject).SetText(Body).Share();
    }



}
