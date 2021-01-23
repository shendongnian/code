    var json = new JObject();
    json.Add("response", new JArray());
    
    using (var reader = dbCommand.ExecuteReader()) {
        while (reader.Read()) {
            ((JArray)json.GetValue("response")).Add( // <- add cast
                new JObject(
                    new JProperty("id", reader.GetString(0)),
                    new JProperty("val", reader.GetString(1))
                )
             );
        }
    }
