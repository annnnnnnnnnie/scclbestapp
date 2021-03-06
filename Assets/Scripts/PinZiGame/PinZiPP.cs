﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script is attached to the pianpang prefab and
 * controls the spritePianpang that should be displayed
 * It also contains the information about the Pianpang displayed
 * Public void SetDisplay(Texture2D texture2D);//Set what to be displayed
 * PinZiPP.selected = bool; //Set selected
 * 
 */
[System.Serializable]
public class PinZiPP : MonoBehaviour, IRecycle {

	private Material curMat;
	private ParticleSystem particalSys;

	private Texture2D side_Unselected;
	private Texture2D side_Selected;

	[HideInInspector]
    public string sidename;

//	private Vector3 v3originalPosition;
//	private static Vector3 v3center = new Vector3(0f, 1.43f, 0f);
	private Behaviour halo;

	public void Start(){
	}

	public void Restart(){
		
	}


	public void Initialize(){
		//Debug.Log ("Getting Renderer.shareMaterial");
		curMat = GetComponent<Renderer> ().sharedMaterial;
		//particalSys = GetComponent<ParticleSystem> ();
		halo = (Behaviour)GetComponent ("Halo");
		halo.enabled = false;
	}

	public void SetDisplay (Texture2D texture2D_Unselected, Texture2D texture2D_Selected){
		side_Unselected = texture2D_Unselected;
		side_Selected = texture2D_Selected;
		curMat.SetTexture ("_MainTex", side_Unselected);
		//sidename = texture2D_Unselected.name;
	}

	void Update(){

	}
	
	public void Shutdown(){
		
	}

	public void SetSelected(){
		//halo.enabled = true;
		curMat.SetTexture ("_MainTex", side_Selected);
		//particalSys = GetComponent<ParticleSystem> ();
		//particalSys.Play ();
		//StopAllCoroutines ();
		//Debug.Log ("Selected: " + sidename);
		//Debug.Log ("when selected, the original location is " + v3originalPosition);
		//StartCoroutine (MoveTo (v3center));
	}
	public void SetUnselected(){
		halo.enabled = false;
		curMat.SetTexture ("_MainTex", side_Unselected);
		//particalSys.Stop();
		//StopAllCoroutines ();
		//Debug.Log ("when unselected, the original location is " + v3originalPosition);
		//StartCoroutine (MoveTo (v3originalPosition));
	}
//
//	public void SetSelected(float time){
//		particalSys = GetComponent<ParticleSystem> ();
//		particalSys.Play();
//		StartCoroutine (PlayForTime (time));
//		StopAllCoroutines ();
//
//	}

	IEnumerator PlayForTime(float t){
		while (t > 0f) {
			t -= Time.deltaTime;
			yield return null;
		}
		particalSys.Stop ();
	}


	IEnumerator MoveTo (Vector3 pos){
		while(!NearMa (transform.position, pos)) {
			Vector3 vel = Vector3.zero;
			//Debug.Log (name + transform.position + " is moving to " + pos);
			transform.position = Vector3.SmoothDamp (transform.position, pos, ref vel, 0.1f);
			yield return null;
		}
	}

	private bool NearMa(Vector3 pos1, Vector3 pos2){
		if (Mathf.Abs (pos1.x - pos2.x) + Mathf.Abs (pos1.y - pos2.y) + Mathf.Abs (pos1.z - pos2.z) < 0.01f) {
			return true;
		} else {
			return false;
		}
	}
}
