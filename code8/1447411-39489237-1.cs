    public GameObject TempText;
    static string TempValue;
    void Start()
    {
        StartCoroutine(GetText());
    }
    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }
    IEnumerator GetText()
    {
        WaitForSeconds waitTime = new WaitForSeconds(2f); //Do the memory allocation once
        string authorization = authenticate("Administrator", "ZZh7y6dn");
        while (true)
        {
            yield return waitTime;
            string url = "http://111.93.149.139:8080/Thingworx/Things/SimulationData/Properties/OvenTemperature/";
            UnityWebRequest www = UnityWebRequest.Get(url);
            www.SetRequestHeader("AUTHORIZATION", authorization);
            yield return www.Send();
            if (www.isError)
            {
                Debug.Log("Error while Receiving: " + www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Char delimiter = '>';
                String[] substrings = result.Split(delimiter);
                foreach (var substring in substrings)
                {
                    if (substring.Contains("</TD"))
                    {
                        String[] Substrings1 = substring.Split('<');
                        Debug.Log(Substrings1[0].ToString() + "Temp Value");
                        TempValue = Substrings1[0].ToString();
                        TempText.GetComponent<TextMesh>().text = TempValue + "'C";
                    }
                }
            }
        }
    }
