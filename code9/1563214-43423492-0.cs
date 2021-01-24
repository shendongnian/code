    public Texture2D texture;
    public void sendData()
    {
        string reqUrl = "http://yourServerUrl.com/app/imagetospeech.php";
        WWWForm reqForm = new WWWForm();
    
        //Add API key
        reqForm.AddField("API_KEY", "AEH392HEIQSKLZ82V4HCBZL093MD");
        //Add Image to convert to Text
        reqForm.AddBinaryData("REQ_IMAGE", texture.EncodeToPNG());
        WWW www = new WWW(reqUrl, reqForm);
        StartCoroutine(WaitForRequest(www));
    }
    
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
    
        //Check if we failed to send
        if (string.IsNullOrEmpty(www.error))
        {
            UnityEngine.Debug.Log(www.text);
        }
    }
