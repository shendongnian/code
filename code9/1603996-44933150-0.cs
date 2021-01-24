    var dictA = a.GetType().GetProperties().ToDictionary(x => x.GetCustomAttributes(false).OfType<JsonPropertyAttribute>().FirstOrDefault()?.PropertyName ?? x.Name, y => y.GetValue(a));
    var dictB = b.GetType().GetProperties().ToDictionary(x => x.GetCustomAttributes(false).OfType<JsonPropertyAttribute>().FirstOrDefault()?.PropertyName ?? x.Name, y => y.GetValue(b));
    var result = new[] { dictA, dictB }.SelectMany(dict => dict)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
    var res = JsonConvert.SerializeObject(result);
    // Result: {"A":"stingAAAA","B":"stringBBBBB","C":"CCC","D2":"DDD"}
