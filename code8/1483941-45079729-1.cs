    public static ConnectionMultiplexer Connection
    {
       get
       {
          return ConnectionMultiplexer.Connect("serverName: port");
       }
    }
    
            public Dictionary<string, string> GetDataFromDataBase(srting sPattern = "*")
            {
             int dbName = 2; //or 0, 1, 2
             Dictionary<string, string> dicKeyValue = new Dictionary<string, string>();
             var keys = Connection.GetServer("serverName: port").Keys(dbName, pattern: sPattern);
             string[] keysArr = keys.Select(key =>(string)key).ToArray();
            
             foreach(var key in keysArr)
             {
               dicKeyValue.Add(key, GetFromDB(dbName , key));
             }
            
             return dicKeyValue;
            }
        
        public string GetFromDB(int dbName, string key)
        {
          var db = Connection.GetDatabase(dbName);
          return db.StringGet(key);
        }
