    	WebClient wc = null;
    	for(int i = 0; i < amount; i++)
    	{
    		progressBar1.Value = 0;
            wc = new WebClient();
        	wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);                        
            wc.DownloadFileAsync(new Uri("abc.com/GetImage.aspx?MSSV="+mssv), mssv.ToString()+".jpg");
    		mssv++;
    	}
        if( wc != null )
        	wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileComplete);
