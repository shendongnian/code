    IEnumerator CheackDBUN(string UsernamePost, Action<string> callback){
        WWWForm form = new WWWForm ();
        form.AddField ("usernamePost", UsernamePost);
    
        WWW userData = new WWW(checkUsernameURL, form);
        yield return userData;
        string userDataString = userData.text;
        Debug.LogWarning("User Data String in CheackDBUN " + userDataString); //Working has text
        callback(userDataString);
    }
