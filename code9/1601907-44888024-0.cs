        AutoResetEvent waiter = new AutoResetEvent(false);
        Ping pingSender = new Ping();
        string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        byte[] buffer = Encoding.ASCII.GetBytes(data);
        int timeout = 100;
        PingOptions options = new PingOptions(64, true);
        IPAddress address = IPAddress.Parse("YourTestIP");
        PingReply reply = pingSender.Send(address, timeout, buffer, options);
        if (reply.Status == IPStatus.Success)
        {
            MessageBox.Show(reply.Address.ToString());
        }
