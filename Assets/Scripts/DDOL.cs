using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    void Awake(){
		GameObject check = GameObject.Find("__app");
		if(check == null){
			UnityEngine.SceneManagement.SceneManager.LoadScene("_preload");
			DontDestroyOnLoad(check);
		}
	}
}
