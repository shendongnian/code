    async private void ApacheTest()
    {
        if(!File.Exists(HTTPD_PATH))
        {
            amountdl.Text = "Apache Not Found! Installation Corrupt!";
            return;
        }
        else
        {
            StartApacheServer();
        }
        amountdl.Text = "Apache Is Starting";
        while(ApacheRunning() == false)
        {
            await Task.Delay(50);
        }
        amountdl.Text = "Apache Started";
    }
