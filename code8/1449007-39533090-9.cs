    private Timer timer = new Timer();
    public void timer_Tick(object sender, EventArgs e)
    {
        byte[][] data;
        // lock the queue as short as possible. (create a copy with ToArray())
        // this way the receive thread can run again..
        // this is also know as bulk processing..
        lock (datagrams)
        {
            data = datagrams.ToArray();
            datagrams.Clear();
        }
        // if no packets received, don't update anything
        if(data.Length == 0)
            return;
        // process the received data (multiple datagrams)
        for(byte[] item in data)
        {
            ...
        }
        // Update chart
    }
