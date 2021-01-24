    try 
    {
        string allData = null; 
        using (var sr = new StreamReader(filePath))
        {
            allData = sr.ReadToEnd() + clientInfo;
        }
    
        File.WriteAllText(filePath, allData);
    }
    catch (IOException exc)
    {
        // exception handling code
    }
    this.Close();
    
