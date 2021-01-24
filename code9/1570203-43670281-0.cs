    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
       writer.WriteStartArray();
       var groupings = (IEnumerable) value;
       var getKey = _keyFetcherForType[value.GetType()];
       foreach (dynamic grouping in groupings) {
          writer.WriteStartObject();
          writer.WritePropertyName("key");
          object key = getKey(grouping);
          if (key == null) {
             writer.WriteNull();
          } else {
             serializer.Serialize(writer, key);
          }
          writer.WritePropertyName("values");
          serializer.Serialize(writer, (IEnumerable) grouping);
          writer.WriteEndObject();
       }
       writer.WriteEndArray();
    }
    // -- snip --- //
    private static class GenericMethodCache<TKey, TValue> {
       public static Func<JArray, JsonSerializer, object> GetLookupMaker() =>
          (jArray, serializer) =>
             jArray
                .Children()
                .Select(jObject => new {
                   Key = jObject["key"].ToObject<TKey>(),
                   Values = jObject["values"].ToObject<List<TValue>>()
                })
                .SelectMany(
                   kvp => kvp.Values,
                   (kvp, value) => new KeyValuePair<TKey, TValue>(kvp.Key, value)
                )
                .ToLookup(kvp => kvp.Key, kvp => kvp.Value);
    
       public static Func<object, object> GetKeyFetcher() =>
          grouping => ((IGrouping<TKey, TValue>) grouping).Key;
    }
