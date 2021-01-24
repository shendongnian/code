    Dictionary<string, object> RecursiveDeserialize(string json)
    {
         var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
         foreach (var pair in result.ToArray())
         {
             if(IsJson(pair.Value))
             {
                 result[pair.Key] = RecursiveDeserialize(pair.Value);
             }
         }
         return result;
    }
