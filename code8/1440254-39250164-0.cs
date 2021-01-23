    using (var w = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "key", "<api-key>" },
            { "image", Convert.ToBase64String(File.ReadAllBytes(@"<file>")) }
        };
        byte[] response = w.UploadValues("http://imgur.com/api/upload.xml", values);
        Console.WriteLine(XDocument.Load(new MemoryStream(response)));
    }
