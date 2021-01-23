    private WebSocket client;
    private void Form1_Load(object sender, EventArgs e)
    {
        client = new WebSocket(host)
        {
            EnableAutoSendPing = true,
            AutoSendPingInterval = 10,
        };
    
        client.Opened += (ss, ee) =>
        {
            System.Diagnostics.Debug.WriteLine("Connected");
        };
    
        client.Error += (ss, ee) =>
        {
            System.Diagnostics.Debug.WriteLine($"Error {ee.Exception}");
        };
    
        client.MessageReceived += (ss, ee) =>
        {
            System.Diagnostics.Debug.WriteLine($"Message: {ee.Message}");
        };
    
        client.Closed += (ss, ee) =>
        {
            System.Diagnostics.Debug.WriteLine("Disconnected");
        };
    
        client.Open();
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (client.State == WebSocketState.Closed)
        {
            client.Open();
            System.Diagnostics.Debug.WriteLine("Trying to reconnect by timer");
        }
    }
