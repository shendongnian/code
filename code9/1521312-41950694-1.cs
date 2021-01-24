    private static void BgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Get argument.
        TcpClient client = e.Argument as TcpClient;
        // Here standart work with buffers. Client.Read(), Client.Write()
    }
