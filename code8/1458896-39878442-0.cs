    string jsonString = "{\"Country\":\"USA\",\"States\":[\"Chicago\",\"Miami\"]}";
    var jss = new JavaScriptSerializer();
    dynamic json = jss.DeserializeObject(jsonString);
    var statesToRemove = new object[] { "Chicago", "Miami" };
    object[] originalStates = json["States"] as object[];
    foreach(var state in statesToRemove)
    {
        json["States"] = new[] { state }; 
        string newJson = jss.Serialize(json);
    }
    // Outputs...
    // {"Country":"USA","States":["Chicago"]}
    // {"Country":"USA","States":["Miami"]}
