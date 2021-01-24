    using Newtonsoft.Json.Linq;
    
    private string CreateJson(string val1, string val2, string val3, string val4, string val5, string val6) 
    {
    
        var configs = new[]
        { 
            new { FirstKey = val1, SecondKey = val2, ThirdKey = val3}, 
            new { FirstKey = val4, SecondKey = val5, ThirdKey = val6}
        };
    
        return JArray.FromObject(configs).ToString();
    }
