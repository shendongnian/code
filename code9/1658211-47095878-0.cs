    private void Form1_Load(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            string path = "c:\\1.jpg";
            for (int i = 0; i < 10; i++)
            {
                string url = "http://...." + i.ToString() + ".jpg";//i'm sure the http file does exist
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                    wc.DownloadFileAsync(new Uri(url), path);
                    Thread.Sleep(3000);//i'm sure the download will be finished in 3s
                    WriteLog("C:\\1.log", "main function\r\n");
                }
            }
        }).Start();
    }
