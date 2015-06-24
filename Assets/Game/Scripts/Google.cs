#pragma strict

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.SocialPlatforms;

public class Google : MonoBehaviour {
	private static NerdGPG m_Instance;

	private enum GPLoginState {loggedout, loggedin};
	private GPLoginState m_loginState = GPLoginState.loggedout;
	private string testLeaderBoard = "testBoard";

//	void Awake()
//	{
//	}

	void Start () {
		Social.Active = new UnityEngine.SocialPlatforms.GPGSocial();
		NerdGPG.Instance().init();
//		Social.localUser.Authenticate((bool success) => {
//			// handle success or failure
//		});
	}

//	void FixedUpdate()
//	{
//		if(PlayerPrefs.GetInt("HighScore") > 5)
//		{
//		}
//		if(PlayerPrefs.GetInt("HighScore") > 5)
//		{
//		}
//		if(PlayerPrefs.GetInt("HighScore") > 5)
//		{
//		}
//		if(PlayerPrefs.GetInt("HighScore") > 5)
//		{
//		}
//		if(PlayerPrefs.GetInt("HighScore") > 5)
//		{
//		}
//	}
	
	void OnMouseDown()
	{
					Social.localUser.Authenticate((bool success) => {
							Social.ReportScore(PlayerPrefs.GetInt("HighScore"), "id", (bool go) => {
							NerdGPG.Instance().showLeaderBoards(testLeaderBoard);
						});
		});
				
	}

	void OnGUI()
	{
		if(Social.localUser.authenticated) {
			GUILayout.Label(Social.localUser.userName + " is signed in. ID: " + Social.localUser.id);
		}
	}

	void OnAuthCB(bool result)
	{
		Debug.Log("GPGUI: Got Login Response: " + result);
	}

	public void OnSubmitScore(bool result)
	{
		Debug.Log("GPGUI: OnSubmitScore: " + result);
	}

	public void GPGAuthResult(string result)
	{
		// success/failed
		if(result == "success") {
			m_loginState = GPLoginState.loggedin;
		} else 
			m_loginState = GPLoginState.loggedout;
	}
}