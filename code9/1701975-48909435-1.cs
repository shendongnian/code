     string Json1 = @"
    {""Property 1"" : ""Value 1"",
    ""Property 2"" : ""Value 2"",
    ""Property 3"" : ""Value 3"",
    ""Property 4"" : ""Value 4""
    }";
    
     string Json2 = @"{
    ""Property 1"" : ""Value 1"",
    ""Property 2"" : ""Value 2"",
    ""Property 6"" : ""Value 6""
    }";
     var Result = IntersectedJson(Json1, Json2);
     Console.WriteLine(Result);
     Console.Read();
     public static string IntersectedJson(string Json1, string Json2)
        {
            var Dictionary1 = JsonConvert.DeserializeObject<Dictionary<string, string>>(Json1);
            var Dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(Json2);
            var result = Dictionary1.Keys.Intersect(Dictionary2.Keys).ToDictionary(t => t, t => Dictionary1[t]);
            return JsonConvert.SerializeObject(result);
        }
