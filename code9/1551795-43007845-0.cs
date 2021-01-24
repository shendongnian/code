    client = new TcpClient();
    
    bool success = false;
    while (success == false)
    {
        try
        {
            IAsyncResult result = client.BeginConnect(IPAddress.Parse("192.168.254.34"), 123, null, null);
            success = result.AsyncWaitHandle.WaitOne(3000, true);
        }
        catch (Exception ex)
        {
            success = false;
            MessageBox.Show("error connecting: " + ex.Message + " : " + ex.StackTrace);
        }
    }
    
    // NOW, by the time you reach this point, you KNOW that success == true and that you're connected, and you can proceed with the rest of your code
    
    STW = new StreamWriter(client.GetStream());
    STR = new StreamReader(client.GetStream());
    STW.AutoFlush = true;
    
    backgroundWorker1.RunWorkerAsync(); // Começar a receber dados em background
    backgroundWorker1.WorkerSupportsCancellation = true; // possibilidade de cancelar o fio
