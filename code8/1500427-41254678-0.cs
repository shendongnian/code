    class ExMessage
    {
       ...
       public static List<ExMessage> CreateMessages(byte[] payload)
       {
          List<byte[]> chunks = ... split payload into 40byte chunks...
          return chunks.Select(p => new ExMessage(p).ToList();     
       }
       ...
    }
