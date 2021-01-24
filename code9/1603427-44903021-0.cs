    private async Task StartClient()
    {
        try
        {
            await client.ConnectAsync(host,port);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.ToString());
        }
    }
