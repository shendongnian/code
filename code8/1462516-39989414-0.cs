    private void getFiles()
    {
        string filelist = "http://somedomain.com/file_list"; 
                label1.Text = "Downloading";
                button2.Image = Properties.Resources.ButtonDisabled;
                progressBar1.Visible = true;
                var webClient = new WebClient();
                string rFile = webClient.DownloadString(filelist);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                foreach (var url in filelist)
                {
                  webClient.DownloadFileTaskAsync(new Uri(Settings1.Default.baseURL + rFile), rFile);
                }
                webClient.DownloadStringCompleted += OnGetDownloadedStringCompleted;
    }
