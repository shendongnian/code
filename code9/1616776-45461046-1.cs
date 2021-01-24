    public static void InputMessagesManager(Action<BtMessage> incomingMessageEvent)
    {
        _tokenSource = new CancellationTokenSource();
        Task t = Task.Factory.StartNew(async () =>
        {
            Stream inputStream = _socket.InputStream;
            while (!_tokenSource.IsCancellationRequested)
            {
                if (inputStream == null)
                    inputStream = _socket.InputStream;
                if (inputStream != null && inputStream.CanRead)
                {
                    await inputStream.ReadAsync(_sizeBuffer, 0, _sizeBuffer.Length);
                    short size = (short)(_sizeBuffer[0] | _sizeBuffer[1] << 8);
                    if (size != 0)
                    {
                        byte[] frame = new byte[size];
                        await inputStream.ReadAsync(frame, 0, frame.Length);
                        BtMessage btMes = new BtMessage(frame);
                        incomingMessageEvent(btMes);
                        Console.WriteLine("Received: " + btMes.name + " -> " + btMes.getValueAsNumber());
                    }
                }
            }
        }, _tokenSource2.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }
