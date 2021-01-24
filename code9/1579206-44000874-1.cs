    public static void Create(byte[] dataToSave)
    {
        //Load old counter
        int counter = PlayerPrefs.GetInt("_counter_", 0);
    
        //Concatenate file name
        string tempPath = Path.Combine(UnityEngine.Application.persistentDataPath, "ocr");
        tempPath = Path.Combine(tempPath, "_");
        tempPath = Path.Combine(tempPath, counter.ToString() + ".jpg");
    
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        }
        //Debug.Log(path);
    
        try
        {
            File.WriteAllBytes(tempPath, dataToSave);
            Debug.Log("Saved Data to: " + tempPath.Replace("/", "\\"));
    
            //Increment Counter
            counter++;
    
            //Save current Counter
            PlayerPrefs.SetInt("_counter_", counter);
            PlayerPrefs.Save();
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To PlayerInfo Data to: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }
