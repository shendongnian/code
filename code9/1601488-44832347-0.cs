    public string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "MyFile");
    public string result = "";
    IEnumerator Example() {
        if (filePath.Contains("://")) 
        {
            WWW www = new WWW(filePath);
            yield return www;
            result = www.text;
        } else
            result = System.IO.File.ReadAllText(filePath);
    }
