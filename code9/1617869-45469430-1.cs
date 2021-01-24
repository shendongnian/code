    private readonly Queue<byte> bigBuffer = new Queue<byte>(1024);
    private readonly SemaphoreSlim _signal = new SemaphoreSlim(0,1);
    // I call this like so:
    // Task.Factory.StartNew(() => beginReading(_shutdownToken), TaskCreationOptions.LongRunning);
    private async Task beginReading(CancellationToken tk)
    {
        byte[] buffer = new byte[1024];
        using (tk.Register(() => m_TcpStream.Close()))
        {
            while (!tk.IsCancellationRequested)
            {
                int bytesReceived = 0;
                if (m_TcpStream.CanRead)
                {
                    bytesReceived = await m_TcpStream.ReadAsync(buffer, 0, buffer.Length);
                }
                if (bytesReceived > 0)
                {
                    for (int i = 0; i < bytesReceived; i++)
                    {
                        bigBuffer.Enqueue(buffer[i]);
                    }
                    _signal.Release();
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
        }
    }
    private async Task<int> ReadAsyncWithTimeout(byte[] buffer, int offset, int count)
    {
        int bytesToBeRead = 0;
        if (bigBuffer.Count > 0)
        {
            bytesToBeRead = bigBuffer.Count < count ? bigBuffer.Count : count;
            for (int i = offset; i < bytesToBeRead; i++)
            {
                buffer[i] = bigBuffer.Dequeue();
            }
        }
        else
        {
            await _signal.WaitAsync(BabelfishConst.TCPIP_READ_TIME_OUT_IN_MS);
            if (bigBuffer.Count > 0)
            {
                bytesToBeRead = bigBuffer.Count < count ? bigBuffer.Count : count;
                for (int i = offset; i < bytesToBeRead; i++)
                {
                    buffer[i] = bigBuffer.Dequeue();
                }
            }
        }
        return bytesToBeRead;
    }
