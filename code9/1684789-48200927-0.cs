    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    
    public class LoginScript : MonoBehaviour {
    
    	public GameObject inputUsernameText;
    	public GameObject inputPasswordText;
    
    	public string inputUsername;
    	public string inputPassword;
    
    	public string userUsername;
    	public string userPassword;
    	public string[] userDataArray;
    
    	string loginURL ="YOUR LOGIN PHP CODE URL HERE" ;
    
    
    	public bool isLoginButtonPressed;
    
    	void Awake() {
    		DontDestroyOnLoad(transform.gameObject);
    	}
    
    	// Use this for initialization
    	void Start () {
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    
    		if (isLoginButtonPressed) 
    		{
    			StartCoroutine(loginToDB (inputUsername, inputPassword));
    			isLoginButtonPressed = false;
    		}
    		
    	}
    
    	 IEnumerator loginToDB(string username, string password)
    	{
    
    		WWWForm form = new WWWForm();
    		form.AddField("usernamePost", username);
    		form.AddField("passwordPost", password);
    
    		WWW www = new WWW (loginURL, form);
    		yield return www;
    		//Debug.Log (www.text);
    		string userEkipIDString = www.text;
    
    		userDataArray = userEkipIDString.Split ('|');
    
    		userUsername = userDataArray [0];
    		userPassword = userDataArray [1];
    		isLoginButtonPressed = false;
    
    		SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    
    
    
    
    	}
    
    	public void loginButtonPressedFunc()
    	{
    		inputUsername = inputUsernameText.GetComponent<Text> ().text.ToString ();
    		inputPassword = inputPasswordText.GetComponent<Text> ().text.ToString ();
    		isLoginButtonPressed = true;
    	}
    
    
    
    
    }
