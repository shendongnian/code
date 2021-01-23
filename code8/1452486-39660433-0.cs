      var selctedList = JObject.Parse("YOUR JSON").SelectToken("Class1List").ToString();
    
      var class1List = JsonConvert.DeserializeObject<Class1[]>(selctedList, new Class1Converter());
 
      public class Class1
            {
                public string Name { get; set; }
            }
    
      public class Class1Converter : JsonCreationConverter<Class1>
            {
                protected override Class1 Create(Type objectType, JObject jObject)
                {
                    return new Class1();
                }
    
            }
    
            public abstract class JsonCreationConverter<T> : JsonConverter
            {
               
                protected abstract T Create(Type objectType, JObject jObject);
    
                public override bool CanConvert(Type objectType)
                {
                    return typeof(T).IsAssignableFrom(objectType);
                }
    
                public override object ReadJson(JsonReader reader,
                                                Type objectType,
                                                 object existingValue,
                                                 JsonSerializer serializer)
                {
                    try
                    {
    
                        // Load JObject from stream
                        JObject jObject = JObject.Load(reader);
    
                        var lp = jObject[jObject.Properties().Select(p => p.Name).FirstOrDefault()];
    
                        JObject kl = JsonConvert.DeserializeObject<JObject[]>(lp.ToString()).FirstOrDefault();
    
                        // Create target object based on JObject
                        T target = Create(objectType, kl);
    
                        // Populate the object properties
                        serializer.Populate(kl.CreateReader(), target);
    
                        return target;
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
    
                public override void WriteJson(JsonWriter writer,
                                               object value,
                                               JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }
