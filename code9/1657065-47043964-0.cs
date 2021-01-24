    var req1 = new MyRequest() { Type = "card", Source = "SomeValue" };
    var json = Serialize(req1);
    var req2 = Deserialize<MyRequest>(json);
---
    string Serialize<T>(T obj)
    {
        var jObj = JObject.FromObject(obj);
        var src = jObj["Source"];
        jObj.Remove("Source");
        jObj[(string)jObj["Type"]] = src;
        return jObj.ToString(Newtonsoft.Json.Formatting.Indented);
    }
    T Deserialize<T>(string json)
    {
        var jObj = JObject.Parse(json);
        var src = jObj[(string)jObj["Type"]];
        jObj.Remove((string)jObj["Type"]);
        jObj["Source"] = src;
        return jObj.ToObject<T>();
    } 
