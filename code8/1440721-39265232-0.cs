     public static byte[] BinarySerialize(IMessage message)
     {
         using (var stream = new MemoryStream())
        {
            var serializer = new SharpSerializer(true);
    
            serializer.Serialize(message, stream );
    
            return stream.ToArray();
        }
    }   
  
