using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class UI_Game_Screen : MonoBehaviour
{
	private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void StartScreen(){
		Debug.Log("shown");
		HandleAnimator("show");
	}
	public virtual void CloseScreen(){
		Debug.Log("hidden");
		HandleAnimator("hide");
	}
	
	void HandleAnimator(string aTrigger){
		if(animator){
			animator.SetTrigger(aTrigger);
		}
	}
}
