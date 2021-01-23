    public async Task CheckForUpdates() {
    	
        using(WebClient wc = new WebClient()) {
        	string s = await wc.DownloadStringTaskAsync("ftp://username:password@wdasd.bplaced.net/test.txt");
        	if(!s.Contains("1.0.0.0") {
        		if (MessageBox.Show("New Update! Would you like to update?", "Yay!",
        			MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
        			System.Windows.Forms.DialogResult.Yes)
        		{
        		   await wc.DownloadFileTaskAsync(
        			"ftp://username:password@wdasd.bplaced.net/wdasd.bplaced.net.zip",
        			@"c:\downloadlocation\tmpupdate.zip"
        		   );
    
                   // do stuff with file downloaded
        		}
        	}
        }
    	return;
    	
    }
