    var headers = client.GetMessageHeaders (i);
    using (var stream = new MemoryStream ()) {
        headers.WriteTo (stream);
        
        var bytes = memory.ToArray ();
        var latin1 = Encoding.GetEncoding (28591);
        string header = latin1.GetString (bytes, 0, bytes.length);
    }
