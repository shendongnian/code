    void Save()
    {
        Save saveData = new Save();
        saveData.extra = 99;
        saveData.highScore = 40;
    
        string jsonData = JsonUtility.ToJson(saveData);
        byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);
        File.WriteAllBytes(Application.dataPath + "/data/settings.text", jsonByte);
    }
