using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject m_backGround;
	public GameObject m_pauseMenu;
	public static bool GameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
			Debug.Log("Escape pressed");
			if(GameIsPaused){
				ResumeGame();
			}else{
				PauseGame();
			}
		}
    }
	public void PauseGame(){
		m_backGround.SetActive(true);
		m_pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void ResumeGame(){
		m_backGround.SetActive(false);
		m_pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	public void QuitGame(){
		Debug.Log("QUIT!");
		Application.Quit();
	}
	public void BackToMain(){
		SceneManager.LoadScene("MainMenu");
	}
}
