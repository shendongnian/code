    [Serializable]
    public class TokenClassName
    {
        public string access_token;
    }
    
    IEnumerator GetAccessToken()
    {
        var url = "http://yoururl.com";
        var form = new WWWForm();
        form.AddField("grant_type", "client_credentials");
        form.AddField("client_id", "login-secret");
        form.AddField("client_secret", "secretpassword");
    
        WWW www = new WWW(url, form);
    
        //wait for request to complete
        yield return www;
    
        //and check for errors
        if (String.IsNullOrEmpty(www.error))
        {
            string resultContent = www.text;
            UnityEngine.Debug.Log(resultContent);
            TokenClassName json = JsonUtility.FromJson<TokenClassName>(resultContent);
            UnityEngine.Debug.Log("Token: " + json.access_token);
        }
        else
        {
            //something wrong!
            UnityEngine.Debug.Log("WWW Error: " + www.error);
        }
    }
