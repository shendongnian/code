    private IEnumerator CallNLU()
    {
        string uri = "https://gateway.watsonplatform.net/natural-language-understanding/api/v1/analyze?version=2017-02-27";
        var headersDict = new Dictionary<string, string>();
        headersDict.Add("Content-Type", "application/json");
        headersDict.Add("Accept", "application/json");
        headersDict.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(USERNAME + ":" + PASSWORD)));
        string parameters = "{\"text\": \"Hello, welcome to IBM Watson!\", \"features\": {\"keywords\":{\"limit\":50}}}";
        byte[] rawData = Encoding.UTF8.GetBytes(parameters);
        WWW www = new WWW(uri, rawData, headersDict);
        yield return www;
        Debug.Log(www.text);
    }
