    using (var stream = message.GetBody<Stream>())
    {
        using (var streamReader = new StreamReader(stream, Encoding.UTF8))
        {
            msg = streamReader.ReadToEnd();
            var obj=JsonConvert.DeserializeObject<DemoMessage>(msg);
        }
    }
