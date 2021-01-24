    Dictionary<string, string> keysAndReplacements = new Dictionary<string, string>();
    // Initialize the dictionary here.
    // Custom logic to perform key prioritization. More on it below.
    IEnumerable<string> prioritizedKeys = PrioritizeKeys(keysAndReplacements.Keys);
    using (StreamReader reader = new StreamReader(@"C:\sample.txt"))
    {
        string allText = reader.ReadToEnd();
        foreach (string key in prioritizedKeys)
        {
            allText = allText.Replace(key, keysAndReplacements[key]);
        }
    }
