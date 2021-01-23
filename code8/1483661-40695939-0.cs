    private void ApacheTest()
    {
        if(!File.Exists(HTTPD_PATH))
        {
            amountdl.Text = "Apache Not Found! Installation Corrupt!";
            **return;** 
        }
        else
        {
            StartApacheServer();
        }
    
        amountdl.Text = "Apache Is Starting";
        while(ApacheRunning() == false)
        {
            System.Thread.Sleep(50);
        }
        amountdl.Text = "Apache Started";
    }
