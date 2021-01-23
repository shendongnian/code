    void Main()
    {
         string jsonResult = "[{\"daterecordedstring\":\"2016-11-21T08:24:42\"}]";
    
        using (var sr = new StringReader(jsonResult))
        using (var jr = new JsonTextReader(sr) { DateParseHandling = DateParseHandling.None })
        {
            var j = JToken.ReadFrom(jr);
            Console.WriteLine(j["value"].ToString()); // prints '2016-11-21T08:24:42'
        }
    }
