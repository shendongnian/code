    using Newtonsoft.Json.Linq;
    
    string json = "[{\"key1\":\"val01\", \"key2\":\"val02\", \"key3\":\"val03\", \"keyn\":\"val0n\"}, {\"key1\":\"val11\", \"key2\":\"val12\", \"key3\":\"val13\", \"keyn\":\"val1n\"}, {\"key1\":\"val21\", \"key2\":\"val22\", \"key3\":\"val23\", \"keyn\":\"val2n\"}]";
    var objects = JArray.Parse(json); // parse as array
    foreach(JObject obj in objects)
    {
        foreach(KeyValuePair<String, JToken> pair in obj)
        {
            Console.WriteLine(pair.Key + " -> " + pair.Value);
        }
    }
