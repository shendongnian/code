      public static object DeserializeFromStream(MemoryStream stream)
            {
                IFormatter formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                object o = formatter.Deserialize(stream);
                return o;
            }
     var body = context.GetBody();
     var totalMessage= JsonDeserializer<TotalMessage>((MemoryStream)body);
