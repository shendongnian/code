    [HttpPost]    
    public string Test([FromBody]Rootobject accounts)
    {
       var json = JsonConvert.SerializeObject(accounts);
       Console.Write("success");
       return json;
    }
