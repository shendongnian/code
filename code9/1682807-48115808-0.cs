    server.OnMessage(ProcessMessage);
    ...
    void ProcessMessage(string s, WebSocketWrapper wrapper)
    {
        Console.WriteLine($"received: {s}");
    }
