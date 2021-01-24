      [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
      public sealed class ImportChildAttribute : Attribute
      {
      }
    
      class ImportChildJsonConverter : JsonConverter
      {
        public override bool CanConvert(Type objectType)
        {
          var attr = CustomAttributeExtensions.GetCustomAttribute(objectType.GetTypeInfo(), typeof(ImportChildAttribute), true);
          if (attr != null)
          {
            var props = objectType.GetProperties();
            if (props.Length != 1)
              throw new NotSupportedException($"Only supports {nameof(ImportChildAttribute)} on classes with one property.");
            return true;
          }
    
          return false;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
          // Deserialize the object into the first property.
          var props = objectType.GetProperties();
          var obj = Activator.CreateInstance(objectType);
          var val = serializer.Deserialize(reader, props[0].PropertyType);
          props[0].SetValue(obj, val);
          return obj;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
          // Find the only property and serialize it.
          var props = value.GetType().GetProperties();
          serializer.Serialize(writer, props[0].GetValue(value));
        }
      }
