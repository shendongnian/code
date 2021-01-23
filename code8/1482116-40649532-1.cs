    for (int i = 0; i < reader.FieldCount; i++)
    {
        string name =reader.GetName(i);
        writer.WritePropertyName(name);
        if(name  == "REQUEST_ID")
        {
           serializer.Serialize(writer, string.Format("{0:n0}",reader[i]));
        }else
        {
          serializer.Serialize(writer, reader[i]);
        }
    }
