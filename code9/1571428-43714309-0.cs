    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
            PropertyInfo[] props = objectType.GetProperties();
            JObject jo = JObject.Load(reader);
            foreach (JProperty jp in jo.Properties())
            {
                if (string.Equals(jp.Name, "name1", StringComparison.OrdinalIgnoreCase) || string.Equals(jp.Name, "name2", StringComparison.OrdinalIgnoreCase))
                {
                    PropertyInfo prop = props.FirstOrDefault(pi =>
                    pi.CanWrite && string.Equals(pi.Name, "CodeModel", StringComparison.OrdinalIgnoreCase));
                    if (prop != null)
                        prop.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                }
            }
            return instance;
        }
