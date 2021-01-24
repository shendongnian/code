    using(var ms = new MemoryStream())
    {
        foreach (var item in data)
        {
            ms.Position = 0;
            ms.SetLength(0); // erase existing data
            ProtoBuf.Serializer.Serialize(ms, item.Value);
    
            list.Add(_database.StringSetAsync(item.Key, ms.ToArray(), expiration));
        }
    }
