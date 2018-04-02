﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverallSceneManager : MonoBehaviour {

	private AsyncOperation async;

	public void LoadScene(string sceneName){
		GameObjectUtility.ClearObjectPools ();
		switch(sceneName){
		case "":
			break;
		default:
			GameObject gO = GameObject.FindWithTag ("Transition");
			switch (sceneName) {
			case "Intro":
				break;
			case "RoomSelection":
				break;
			case "HomeScreen":
				break;
			case "NewPinZiGame":
				break;
			case "maze":
				break;
			}
			if (gO != null)
				gO.GetComponent<SceneTransitionAnimator> ().PlayTransition ();
			StartCoroutine (LoadSceneAfterTime (1.3f, sceneName));
			break;
		}
	}

	IEnumerator LoadSceneAfterTime(float t, string sceneName){
		//yield return new WaitForSeconds (t);
		//SceneManager.LoadScene (sceneName);
		yield return StartCoroutine(LoadSceneAsync(sceneName));
		
	}
	
	IEnumerator LoadSceneAsync (string sceneName){
		yield return new WaitForSeconds (0.5f);
		async = SceneManager.LoadSceneAsync(sceneName);
		while (!async.isDone) {
			yield return null;
		}
	}
	
	//-------------------------------
	public void LoadSceneForUI(){
		GameObjectUtility.ClearObjectPools ();
		CharacterSpawner.EndGameClear ();
		LoadSceneAsync ("BuildingOne");
	}

	public static void EnterGame(string gameName){
	}
}
