    var unSerialized =
        new Dictionary<string, Dictionary<string, string>>
            (JsonConvert
                .DeserializeObject<Dictionary<string, Dictionary<string, string>>>(serialized),
                dict.Comparer);
