    NpcAI.RegisteredNpc = new CDictionnary<string, List<string>>();
    NpcAI.RegisteredNpc.Add("Ballons", new List<string>()
    {
        "1", //id    
        "Ballons" // name
    });
    NpcAI.RegisteredNpc.Add("Ballons", new List<string>()
    {
        "2", //id
            "lons" // name    
    });
	
    foreach(KeyValuePair<string, List<string>> npc in NpcAI.RegisteredNpc)
    {
        using(SqlDatabaseClient client = SqlDatabaseManager.GetClient())
        {
            client.ClearParameters(); 
            client.SetParameter("id", npc.Value[0]); // will get the first value so it'll be 1 or 2
            client.SetParameter("name", npc.Value[1]); // will get the second value, so it'll be either "Ballons" or "lons"     
            client.ExecuteNonQuery("INSERT INTO `npc`(`id`, `name`) VALUES (@id, @name)");
        }
    }       
