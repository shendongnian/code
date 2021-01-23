    void Load()
    {
        //Load saved Json
        byte[] jsonByte = File.ReadAllBytes(Application.dataPath + "/data/settings.text");
    
        //Convert to string
        string jsonData = Encoding.ASCII.GetString(jsonByte);
    
        //Convert to Class
        Save loadedData = JsonUtility.FromJson<Save>(jsonData);
    
        //Display saved data
        Debug.Log("Extra: " + loadedData.extra);
        Debug.Log("High Score: " + loadedData.highScore);
    
        for (int i = 0; i < loadedData.ID.Count; i++)
        {
            Debug.Log("ID: " + loadedData.ID[i]);
        }
        for (int i = 0; i < loadedData.Amounts.Count; i++)
        {
            Debug.Log("Amounts: " + loadedData.Amounts[i]);
        }
    }
