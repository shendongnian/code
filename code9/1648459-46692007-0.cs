    var s = @"
        {
            ""obj"": {
                ""foo"": ""bar""
            },
            ""arr"": [
                1,
                2,
                3
            ]
        }
    ";
    using(var sr = new System.IO.StringReader(s))
    {
        var r = new Newtonsoft.Json.JsonTextReader(sr);
        while (r.Read())
            Console.WriteLine(r.LineNumber + ":" + r.LinePosition + " : " + r.Path);
    }
