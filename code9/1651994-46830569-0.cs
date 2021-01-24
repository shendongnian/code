    var settings=new JsonSerializerSettings{ 
        DateParseHandling = DateParseHandling.DateTimeOffset
    };
    dynamic json = JsonConvert.DeserializeObject( result, settings);
    var value=(DateTimeOffset)(json.records[0].LastModifiedDate.Value);
    Console.WriteLine("{0:o}",value);
