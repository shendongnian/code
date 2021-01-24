    IEnumerator ReadFromStreamingAssets()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "MyFile");
        string result = "";
        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();
            result = www.downloadHandler.text;
        }
        else
            result = System.IO.File.ReadAllText(filePath);
    }
