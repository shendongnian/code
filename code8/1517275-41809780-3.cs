    public static void deserializeXml<T>(this T toDeserialize, string filename)
    {
       // !!!! toDeserialize is a copy to instance in the heap, so -> ...
       XmlSerializer xmlSerializer = new XmlSerializer(toDeserialize.GetType());
    
       Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
       // -> ... here we assign reference of deserialized instance to toDeserialize(which is a copy)
       toDeserialize = (T) xmlSerializer.Deserialize(stream);
      
       // we need to return result here, otherwise this reference copy will be left dying here
    }
