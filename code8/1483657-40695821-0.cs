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
    	
    	while(ApacheRunning() == false)
        {
          amountdl.Text = "Apache Is Starting";
        }
        
        amountdl.Text = "Apache Started";
        
    }
