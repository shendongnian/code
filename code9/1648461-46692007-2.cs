    var charIndex = 48;
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
    s = s.Replace("\n", " ").Replace("\r", " ");
    var path = "";
    using(var sr = new System.IO.StringReader(s))
    {
        var r = new Newtonsoft.Json.JsonTextReader(sr);
        while (r.Read() && r.LinePosition <= charIndex )
            path = r.Path;
    }
    Console.WriteLine(path); // obj.foo
