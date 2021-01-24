    /// <summary>
    /// Non standard json serialization (object one by one) Highly discouraged unless you have specific reason
    /// Assuming the output will not have internal objects 
    /// </summary>
    public void SerializeNonStandard()
    {
        List<Account> listOfAccounts = new List<Account>();
        listOfAccounts.Add(new Account { Id = 1, Name = "First" });
        listOfAccounts.Add(new Account { Id = 2, Name = "Second" });
        listOfAccounts.Add(new Account { Id = 3, Name = "Third" });
                
        foreach (var item in listOfAccounts)
        {
            string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented);
            File.AppendAllText(@"c:\temp\data-ns.json", outputJSON + Environment.NewLine);
        }
    }
    /// <summary>
    /// Deserializes the list in one by one fashion and appends to list
    /// </summary>
    public void DeSerializeNonStandard()
    {
        if (File.Exists(@"c:\temp\data-ns.json"))
        {
            List<Account> listOfAccounts = new List<Account>();
            String JSONtxt = File.ReadAllText(@"c:\temp\data-ns.json");
    
            //Capture JSON string for each object, including curly brackets 
            Regex regex = new Regex(@".*(?<=\{)[^}]*(?=\}).*", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(JSONtxt);
            foreach(Match match in matches)
            {
                string objStr = match.ToString();
                Account account = Newtonsoft.Json.JsonConvert.DeserializeObject<Account>(objStr);
                listOfAccounts.Add(account);
            }
        }
    }
    
    /// <summary>
    /// Deserializes the non standard json to list of accounts
    /// Splits the object strings, merges with comma and encloses with [] to make it array of objects format and deserializes
    /// </summary>
    public void DeSerializeNonStandardList()
    {
        if (File.Exists(@"c:\temp\data-ns.json"))
        {
            String JSONtxt = File.ReadAllText(@"c:\temp\data-ns.json");
    
            //Capture JSON string for each object, including curly brackets 
            Regex regex = new Regex(@".*(?<=\{)[^}]*(?=\}).*", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(JSONtxt);
    
            string joinedJSON = string.Join(",", matches.Cast<Match>().Select(m => m.Value));
            joinedJSON = string.Format("[{0}]", joinedJSON);
    
            var listOfAccounts = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Account>>(joinedJSON);
    
        }
    }
