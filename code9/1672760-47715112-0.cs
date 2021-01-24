            public void StartRoutineCheckLoginCorrect (string username, string password, string url, Action<string[]> callback)
        {
            StartCoroutine (Login (username, password, url, callback));
        }
     
        IEnumerator Login (string username, string password, string url,Action<string[]> callback)
        {
            string loginURL = "http://" + url + "/Unity/mylogin.php";
            WWWForm form = new WWWForm ();
            form.AddField ("username", username);
            form.AddField ("password", password);
     
            WWW users_get = new WWW (loginURL, form);
     
            yield return users_get;
     
            if (users_get.error != null && users_get.error != "") {
                Debug.Log ("Login failed");
     
            } else {
                string[] temp = users_get.text.Split ("*".ToCharArray ());
     
                if (temp.Length <= 2 || temp [0].ToString () == "Username or password false") {
                    Debug.Log (temp [0].ToString ());
                    login = false;
                } else {
                    Debug.Log ("Login succeeded");
                    login = true;
                    callback (temp);
                }
            }
        }
     
        public void StartRoutineGetProjects(string id, string username, string url, Action<string[]> callback){
            StartCoroutine (GetProjects (id, username, url,callback));
        }
     
        public IEnumerator GetProjects (string id, string username, string url, Action<string[]> callback)
        {
            string privateURL = "http://" + url + "/Unity/myprojects.php";
     
            WWWForm form = new WWWForm ();
            form.AddField ("id", id);
            form.AddField ("username", username);
     
            WWW projects_get = new WWW (privateURL, form);
     
            yield return projects_get;
     
            if (projects_get.error != null && projects_get.error != "") {
                Debug.Log ("Internal error");
                callback (null);
            } else {
                string[] tempProjects = projects_get.text.Split ("|".ToCharArray ());
     
                callback (tempProjects);
     
            }
        }
