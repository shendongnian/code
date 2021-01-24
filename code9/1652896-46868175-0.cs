    public string GetScript(string scriptName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "Q46868043.SQL_scripts." + scriptName;
    
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
