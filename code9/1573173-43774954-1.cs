    /// <summary>
    /// Serializing the list in single go
    /// </summary>
    public void Serialize()
    {
        List<Account> listOfAccounts = new List<Account>();
        listOfAccounts.Add(new Account { Id = 1, Name = "First" });
        listOfAccounts.Add(new Account { Id = 2, Name = "Second" });
        listOfAccounts.Add(new Account { Id = 3, Name = "Third" });
    
        string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(listOfAccounts, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(@"c:\temp\data.json", outputJSON + Environment.NewLine);
    }
    
    /// <summary>
    /// Serializing the list, one by one object
    /// Comma is appended to every object in json format
    /// Finally, enclosed it with [ and ] to make it array of objects
    /// </summary>
    public void Serialize2()
    {
        List<Account> listOfAccounts = new List<Account>();
        listOfAccounts.Add(new Account { Id = 1, Name = "First" });
        listOfAccounts.Add(new Account { Id = 2, Name = "Second" });
        listOfAccounts.Add(new Account { Id = 3, Name = "Third" });
        string outputJSON = "";
        foreach(var item in listOfAccounts)
        {
            outputJSON += Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented)+",";
        }
                
        File.WriteAllText(@"c:\temp\data.json", "["+outputJSON + "]");
    }
    
    /// <summary>
    /// Read serialized data into list of objects
    /// </summary>
    public void DeSerialize()
    {
        if (File.Exists(@"c:\temp\data.json"))
        {
            String JSONtxt = File.ReadAllText(@"c:\temp\data.json");
            var accounts = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Account>>(JSONtxt);
        }
    }
    
