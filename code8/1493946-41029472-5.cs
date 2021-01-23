    private Dictionary<string, Dictionary<string, Dictionary<string, string>>> zooDict =
         new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
    while (reader.Read())
    {
           var location = reader.GetString(0).Trim();
           var animal= reader.GetString(1).Trim();
           var Monday= reader.GetValue(1).ToString().Trim();
           var Tuesday= reader.GetValue(3).ToString().Trim();
           if(!zooDict.ContainsKey(location))
                zooDict[location] = new Dictionary<string, Dictionary<string, string>>();
              
           zooDict[location][animal] = new Dictionary<string, string>() 
           {
                 { "MN", Monday },
                 { "Tu", Tuesday }
           };
    }
