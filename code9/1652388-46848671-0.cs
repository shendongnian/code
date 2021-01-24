    var stream = new MemoryStream();
    // notice the true as last parameter, false is the default.
    using(var writer = new StreamWriter(stream, Encoding.UTF8, 8196, true))
    {
        var i = entries.Length;
        foreach (var entry in entries)
        {
            i--;
            writer.WriteLine(row(entry)); // simply call to overridden ToString() method
        }
    }
    // your streamwriter has now flushed its buffer and left the stream open
    stream.Seek(0, SeekOrigin.Begin);
    // calling Flush on the stream was never needed so I removed that.
    response.Content = new StreamContent(stream);
