    // memory
    using (var mem = new MemoryStream())
    {
      Serializer.Serialize<Message>(mem, msg);
      var bytes = mem.GetBuffer();
    }
    
    // file
    using (var file = File.Create("message.bin")) Serializer.Serialize<Message>(file, msg);
