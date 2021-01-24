    .       using(var ms = new MemoryStream())
    .       {
    .          var formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Position =0;
            return (T)formatter.Deserialize(stream);
         }
    .    }’
