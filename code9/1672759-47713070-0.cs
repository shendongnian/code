    	public string[] StartRoutineGetProjects(string username, string password, string url){
		string[] temp;
	    StartCoroutine(GetProjects(username, password, url,(stringArray)=>{
			temp = stringArray;
		}));
	}
	public IEnumerator GetProjects (string username, string password, string url, Action<string[]> callback)
	{
		string privateURL = "http://" + url + "/Unity/myprojects.php";
		WWWForm form = new WWWForm ();
		form.AddField ("username", username);
		form.AddField ("password", password);
		// send WWWForm
		WWW projects_get = new WWW (privateURL, form);
		// Receiving projects
		yield return projects_get;
		if (projects_get.error != null && projects_get.error != "") {
			Debug.Log ("Interner Fehler");
			callback (null);
		} else {
			// splitting the result at "|"
			string[] tempProjekte = projects_get.text.Split ("|".ToCharArray ());
			callback (tempProjekte);
		}
	}
