    class SimpleObject
    {
       public string UserId { get; set; }
    }
    
    var obj = JsonConvert.DeserializeObject<UserIDObj>("{\"name\":\"XX\", \"userId\":\"YYY\",\"age\":\"10\"}");
    string usrID = obj.UserId;
