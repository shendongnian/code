    IBuffer buffMsg;
    
    DataContractSerializer sessionSerializer = new DataContractSerializer(typeof(Player));
    using (var stream = new MemoryStream())
    {
        sessionSerializer.WriteObject(stream, player);
    
        buffMsg = stream.ToArray().AsBuffer();
    }
