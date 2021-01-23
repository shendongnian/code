    public class payload
    {
        public string id;
        public string type;
        public DateTime timestmap;
        public dynamic data;
    }
    payload result = new payload();
    var resultList = new List<Dictionary<string, dynamic>>();
    result.id = "someid";
    
    //connection stuff
    
    while (reader.Read())
    {
    
        var t = new Dictionary<string, dynamic>();
        for (var i = 0; i<reader.FieldCount; i++)
        {
            t[reader.GetName(i)] = reader[i];
        }
        resultList.Add(t);
    }
    
    result.data = resultList;
    result.timestmap = DateTime.Now;
    result.type = "complex";
    string output = JsonConvert.SerializeObject(result);
   
