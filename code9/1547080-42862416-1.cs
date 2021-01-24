      WebClient client = new WebClient();
      client.DownloadDataCompleted += DownloadDataCompleted;
      client.DownloadDataAsync(new Uri("http://ipv4.icanhazip.com"));
       
    	
    static void DownloadDataCompleted(object sender,
        DownloadDataCompletedEventArgs e)
    {
        byte[] raw = e.Result;
        string data = System.Text.Encoding.Default.GetString(raw);
    	data = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                                 .Matches(data)[0].ToString();
        Logging.WriteLog("External IP: " + data);							 
    }
