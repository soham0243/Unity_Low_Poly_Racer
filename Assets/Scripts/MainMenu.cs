using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject backGround;
	
	void Start(){
		backGround.SetActive(true);
		mainMenu.SetActive(true);
		optionsMenu.SetActive(false);
	}
    public void PlayGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("Game");
	}
	public void QuitGame(){
		Debug.Log("QUIT!");
		Application.Quit();
	}
	bool int_bool(int i){
		return (i == 1) ? true : false;
	}
}
