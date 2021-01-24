    private IEnumerator LoadFile()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "file.txt");
        if(filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            if(string.IsNullOrEmpty(www.error))
            {
                _query_TOP = www.text;
            }
        }
        else
        {
            _query_TOP = System.IO.File.ReadAllText(filePath);
        }
    }
