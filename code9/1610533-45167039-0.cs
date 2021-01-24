    private static IEnumerable<string> GetMembers(JToken jToken)
    {
        var members = new List<string>();
        if (jToken is JObject)
        {
            var jObject = (JObject)jToken;
            foreach (var prop in jObject.Properties())
            {
                if (prop.Value is JValue)
                {
                    members.Add(prop.Name);
                }
                else
                {
                    members.AddRange(GetMembers(prop.Value).Select(member => prop.Name + "." + member));
                }
            }
        }
        else if (jToken is JArray)
        {
            var jArray = (JArray)jToken;
            for (var i = 0; i < jArray.Count; i++)
            {
                var token = jArray[i];
                members.AddRange(GetMembers(token).Select(member => i + "." + member));
            }
        }
        return members;
    }
