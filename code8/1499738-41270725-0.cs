    using (var jsonReader = new JsonReader(text))
    {
       var serializer = new BsonArraySerializer();
       var bsonArray = serializer.Deserialize(BsonDeserializationContext.CreateRoot(jsonReader));
    }
