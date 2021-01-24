    string k = @"
    {""Property 1"" : ""Value 1"",
    ""Property 2"" : ""Value 2"",
    ""Property 3"" : ""Value 3"",
    ""Property 4"" : ""Value 4""
    }";
    
                string k2 = @"{
    ""Property 1"" : ""Value 1"",
    ""Property 2"" : ""Value 2"",
    ""Property 6"" : ""Value 6""
    }";
                var Dictionary1 = JsonConvert.DeserializeObject<Dictionary<string,string>>(k);
                var Dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(k2);
                var result = Dictionary1.Keys.Intersect(Dictionary2.Keys).ToDictionary(t => t, t => Dictionary1[t]);
