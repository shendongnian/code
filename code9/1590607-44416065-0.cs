        BinaryFormatter formatter = new BinaryFormatter();            
        //Serialize
        string serialized;
        using (MemoryStream stream = new MemoryStream())
        {
            // pass FormCollection to constructor of new NameValueCollection
            // that way we kind of convert it to NameValueCollection which is serializable
            // of course we lost any FormCollection-specific details (if there were any)
            formatter.Serialize(stream, new NameValueCollection(data));
            serialized = Convert.ToBase64String(stream.ToArray());                
        };
        //Deserialize
        using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(serialized))) {
            // deserialize as NameValueCollection then create new 
            // FormCollection from that
            data = new FormCollection((NameValueCollection) formatter.Deserialize(stream));
        }
