    protected virtual void OnConnected(ConnectedArgs e) {
        System.IO.File.WriteAllText(@"C:\Users\Bailey Miller\Desktop\FTP\Logg.txt", "Hit OnConnected " + e.Success +" " + Connected != null ? "Isn't null" : "Null event");
        ConnectedToHubEventHandler connectedEvent = Connected;
        if (connectedEvent != null) // This event might be null, so check first
            connectedEvent(null, e);
    }
