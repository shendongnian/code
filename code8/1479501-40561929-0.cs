    public async Task Send(object data)
    {
        var newTask = Task.Run(async () =>
        {
            MemoryStream ms = new MemoryStream();
            _serializer.Serialize(ms, data, Settings.Serialisation);
            if (Settings.UseCompression)
                ms = new MemoryStream(_compression.Compress(ms));
            if (Settings.Stream.AppendSignature)
                new MemoryStream(Settings.Stream.Signature).CopyTo(ms);
            Send(ms.ToArray());
            ms.Dispose();
        });
        return newTask;
    }
    public void Send(byte[] data)
    {
        try
        {
            lock (_lock)
            {
				Task[] tasks = _clients.Select(c => c.Send(data)).ToArray();
				await Task.WhenAll(tasks);
            }
        }catch(System.Exception ex)
        {
            ExceptionHandler.HandleException(ex, "Error while sending data", this);
        }
    }
