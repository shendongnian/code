    public void downloadImage(string url, string pathToSaveImage)
    {
        WWW www = new WWW(url);
        StartCoroutine(_downloadImage(www, pathToSaveImage));
    }
    
    private IEnumerator _downloadImage(WWW www, string savePath)
    {
        yield return www;
    
        //Check if we failed to send
        if (string.IsNullOrEmpty(www.error))
        {
            UnityEngine.Debug.Log("Success");
    
            //Save Image
            saveImage(savePath, www.bytes);
        }
        else
        {
            UnityEngine.Debug.Log("Error: " + www.error);
        }
    }
    
    void saveImage(string path, byte[] imageBytes)
    {
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    
        try
        {
            File.WriteAllBytes(path, imageBytes);
            Debug.Log("Saved Data to: " + path.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Save Data to: " + path.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }
    
    byte[] loadImage(string path)
    {
        byte[] dataByte = null;
    
        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Debug.LogWarning("Directory does not exist");
            return null;
        }
    
        if (!File.Exists(path))
        {
            Debug.Log("File does not exist");
            return null;
        }
    
        try
        {
            dataByte = File.ReadAllBytes(path);
            Debug.Log("Loaded Data from: " + path.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Load Data from: " + path.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    
        return dataByte;
    }
