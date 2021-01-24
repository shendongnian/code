    IEnumerator downloadAsset()
    {
        string url = "http://url.net/YourAsset.unity3d";
    
        UnityWebRequest www = UnityWebRequest.Get(url);
        DownloadHandler handle = www.downloadHandler;
    
        //Send Request and wait
        yield return www.Send();
    
        if (www.isError)
        {
    
            UnityEngine.Debug.Log("Error while Downloading Data: " + www.error);
        }
        else
        {
            UnityEngine.Debug.Log("Success");
    
            //handle.data
    
            //Construct path to save it
            string dataFileName = "WaterVehicles";
            string tempPath = Path.Combine(Application.persistentDataPath, "AssetData");
            tempPath = Path.Combine(tempPath, dataFileName + ".unity3d");
    
            //Save
            save(handle.data, tempPath);
        }
    }
    
    void save(byte[] data, string path)
    {
        //Create the Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    
        try
        {
            File.WriteAllBytes(path, data);
            Debug.Log("Saved Data to: " + path.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Save Data to: " + path.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }
