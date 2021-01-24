    // Default dictionary
    Dictionary<int, DictionaryCheckup> H = new Dictionary<int, DictionaryCheckup>()
    {
        {180000, new DictionaryCheckup {theGrouping = "H"}},
        {180001, new DictionaryCheckup {theGrouping = "H"}},
        {180303, new DictionaryCheckup {theGrouping = "H"}},
    };
    
    // Then when we plan on loading our dictionary...
    
    // Write our our default JSON if no config file exists
    if (!File.Exists("H.json"))
    {
        using (var stream = new StreamWriter(File.Create("H.json")))
        {
            // Convert our "H" dictionary into JSON
            var json = JsonConvert.SerializeObject(H, Formatting.Indented);
            
            // Write the JSON to the file
            stream.Write(json);
            stream.Flush();
        }
    }
    // Read the JSON that our user has configured
    else
    {
        using (var stream = new StreamReader(File.OpenRead("H.json")))
        {
            // Read our JSON from the file
            var json = stream.ReadToEnd();
            
            // Convert it back to a Dictionary<int, DictionaryCheckup> object and store
            // it in our "H" variable
            H = JsonConvert.DeserializeObject<Dictionary<int, DictionaryCheckup>>(json);
        }
    }
