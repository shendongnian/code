    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }
    IEnumerator makeRequest()
    {
        string authorization = authenticate("YourUserName", "YourPassWord");
        string url = "yourUrlWithoutUsernameAndPassword";
    
    
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("AUTHORIZATION", authorization);
    
        yield return www.Send();
        .......
    }
