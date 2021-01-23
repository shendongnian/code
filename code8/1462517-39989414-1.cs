        private async void getFiles()
        {
            string filelist = "http://somedomain.com/file_list";
            //label1.Text = "Downloading";
            //button2.Image = Properties.Resources.ButtonDisabled;
            //progressBar1.Visible = true;
            using (var webClient = new WebClient())
            {
                webClient.DownloadStringCompleted += OnGetDownloadedStringCompleted;
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                var rFile = webClient.DownloadString(filelist);
                //rFile needs broken up somehow since it is a string and not an array... unless you want the characters to be the array... which is odd.
                //So for dummying the code to work for now...
                var rFiles = rFile.Split(',');
                foreach (var url in rFiles)
                    await webClient.DownloadFileTaskAsync(new Uri(Settings1.Default.baseURL + url), rFile);
            }
        }
