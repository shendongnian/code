    var childSocketThread = new Thread(() =>
    {
        byte[] data = new byte[10000];
        int size = client.Receive(data);  // <-- the application hangs on these.
        ParseData(System.Text.Encoding.Default.GetString(data));
        client.Close();
    });
    childSocketThread.IsBackground = true;   // <---
    childSocketThread.Start();
