    public void format(object nObject)
    {
        var obj = JObject.FromObject(nObject);
        foreach (var row in obj)
        {
            var key = row.Key;
            string value;
            switch (row.Value.Type)
            {
                case JTokenType.Array:
                    value = ((JArray) row.Value).Count.ToString();
                    break;
                case JTokenType.Boolean:
                    value = ((Boolean)row.Value)? "Да" : "Нет";
                    break;
                default:
                    value = row.Value.ToString();
                    break;
            }
            Debug.Log($"Key{key}={value}");
        }
    }
