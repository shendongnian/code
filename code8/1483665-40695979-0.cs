    private void ApacheTest()
    {
        if(!File.Exists(HTTPD_PATH))
        {
            amountdl.Text = "Apache Not Found! Installation Corrupt!";
        }
        else
        {
            StartApacheServer();
        }
        amountdl.Text = "Apache Is Starting";
        while(ApacheRunning() == false)
        {
            Thread.Sleep(200);
        }
        
        amountdl.Text = "Apache Started";
    }
