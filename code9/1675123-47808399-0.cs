    IEnumerator loadStreamingAsset(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
    
        string result;
    
        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            result = www.text;
        }
        else
        {
            result = System.IO.File.ReadAllText(filePath);
        }
    
        Debug.Log("Loaded file: " + result);
    }
