    ...
    MemoryStream output = new MemoryStream();
    input.Seek(2, SeekOrigin.Begin);
    using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
    {
        dstream.CopyTo(output);
    }
    string myStr = Encoding.ASCII.GetString(output.ToArray());
    return myStr;
