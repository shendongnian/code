    var items = new Dictionary<object, Dictionary<string, object>>();
    while (sqlDataReader.Read())
    {
        var item = new Dictionary<string, object>(sqlDataReader.FieldCount - 1);
        for (var i = 1; i < sqlDataReader.FieldCount; i++)
        {
            item[sqlDataReader.GetName(i)] = sqlDataReader.GetValue(i);
        }
        items[sqlDataReader.GetValue(0)] = item;
    }
    var json = Newtonsoft.Json.JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
