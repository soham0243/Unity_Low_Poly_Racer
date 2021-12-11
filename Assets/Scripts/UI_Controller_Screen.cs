using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Controller_Screen : MonoBehaviour
{
	private Component[] screens = new Component[0];
	public UI_Game_Screen m_StartScreen;
	private UI_Game_Screen previousScreen;
	public UI_Game_Screen PrevoiusScreen{get{return previousScreen;}}
	private UI_Game_Screen currentScreen;
	public UI_Game_Screen CurrentScreen{get{return currentScreen;}}
    // Start is called before the first frame update
    void Start()
    {
        screens = GetComponentsInChildren<UI_Game_Screen>(true);
		InitializeScreen();
    }
	
	public void SwitchScreens(UI_Game_Screen aScreen){
		if(aScreen){
			if(currentScreen){
				currentScreen.CloseScreen();
				previousScreen = currentScreen;
			}
			currentScreen = aScreen;
			currentScreen.gameObject.SetActive(true);
			currentScreen.StartScreen();
		}
	}
	public void GoToPreviousScreen(){
		if(previousScreen){
			SwitchScreens(previousScreen);
		}
	}
	void InitializeScreen(){
		foreach(var screen in screens){
			screen.gameObject.SetActive(true);
		}
	}
}
