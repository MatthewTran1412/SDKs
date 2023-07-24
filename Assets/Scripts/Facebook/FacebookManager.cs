using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookManager : MonoBehaviour
{
	public Text userName;
	public Image Avatar;
	void Start() {
	    try { FB.Init(this.initComplete, this.onHideUnity); }
	    catch (System.Exception ex) { Debug.Log(ex.ToString()); }
	}
	private void initComplete() {
	    Debug.Log($"Initialize -> {FB.IsLoggedIn}, {FB.IsInitialized}");
		DealWithFbMenus(FB.IsLoggedIn);
	}
	private void onHideUnity(bool isGameShown) {
	    Debug.Log($"isGameShown: {isGameShown}");
	}
	public void loginFacebook() {
	    try {
	        List<string> permissions = new List<string>();
	        permissions.Add("public_profile");
	        permissions.Add("user_friends");
	        FB.LogInWithReadPermissions(permissions, handleResult);
	    }
	    catch (System.Exception ex) {
	        Debug.Log(ex.ToString());
	    }
	}
	private void handleResult(IResult result) {
	    if (result.Error != null) { Debug.Log(result.Error); }
	    else {
	        if (FB.IsLoggedIn) { Debug.Log("Facebook is Login!"); }
	        else { Debug.Log("Facebook is not Logged in!"); }
	    }
		DealWithFbMenus(FB.IsLoggedIn);
	}
    public void FacebookLogout()
    {
    	if (FB.IsLoggedIn)
    	{                                                                                  
    	    FB.LogOut();
    	} 
    }
	private void DealWithFbMenus(bool isLoggedIn)
	{
	    if(isLoggedIn)
	    {
	        FB.API("/me?fields=first_name",HttpMethod.GET,DisplayUsername);
	        FB.API("/me/picture?type=square&height=128&width=128",HttpMethod.GET,DisplayProfilePic);
	    }
	}
	private void DisplayUsername(IResult result)
	{
	    if(result.Error==null)
	    {
	        userName.text = "" + result.ResultDictionary["first_name"];
	    }
	    else
	        Debug.Log(result.Error);
	}
	private void DisplayProfilePic(IGraphResult result)
	{
	    if(result.Texture !=null)
	    {
	        Avatar.sprite = Sprite.Create(result.Texture,new Rect(0,0,128,128),new Vector2());
	    }
	    else
	        Debug.Log(result.Error);
	}
}