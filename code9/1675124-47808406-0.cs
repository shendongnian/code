    public void WriteDataToFile(string jsonString)
    {
    
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            File.WriteAllText(filePath, jsonString);
        }
        else
        {
            File.WriteAllText(filePath, jsonString);
        }
    
    }
