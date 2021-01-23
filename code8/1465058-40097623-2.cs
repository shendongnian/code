    void Load()
    {
        //Load saved Json
        string jsonData = PlayerPrefs.GetString("MySettings");
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
