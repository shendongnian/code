    private void open()
    {
    	OpenFileDialog open = new OpenFileDialog();
    	open.Filter = "zip Datei (.zip)|*.zip";
    	open.RestoreDirectory = true;
    
    	if (open.ShowDialog() == DialogResult.OK)
    	{
    		
    			Thread t1 = new Thread
    			(delegate()
    			{
    				try
    				{
    					using (ZipFile zip = Ionic.Zip.ZipFile.Read(open.FileName))
    					{
    						zip.ExtractProgress += zip_ExtractProgress;
    						zip.ExtractAll(".\\", ExtractExistingFileAction.OverwriteSilently);
    					}
    				}
    				catch (ZipException zex)
    				{
    					error(zex.Message);
    				}
    			 });
    			t1.IsBackground = true;
    			t1.Start();
    		
    	}
    }
    
    
    private void zip_ExtractProgress(object sender, ExtractProgressEventArgs args)
    {
    	 update(args.TotalBytesToTransfer, args.BytesTransferred);
    }
    
    
    
    private void update(long ueTotal, long done)
    {
    	
    	if (this.InvokeRequired)
    	{
    		this.Invoke(new MethodInvoker(() => { update(ueTotal, done); }));
    	}
    	else
    	{
    		if (ueTotal > 0)
    		{
    			double prz = (100d / ueTotal) * done;
    			lblProz.Text = prz.ToString("###.##");
    		}
    	}
    }
     
