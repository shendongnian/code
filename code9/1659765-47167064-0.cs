    using( var inputStream = new MemoryStream() )
    {
      tcp.GetStream().CopyTo(inputStream);
      Encoding.ASCII.GetString(inputStream.ToArray());
      listBox1.Items.Add(dataReceived);
      ...
    }
