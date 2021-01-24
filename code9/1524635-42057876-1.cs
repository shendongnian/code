    BackgroundWorker bw = new BackgroundWorker();
    int currentLine = 0;
    ProgressBar progressBar1 = new ProgressBar();
    string[] lines;
    private void btnIndir_Click(object sender, EventArgs e)
        {
            lines = YourAllLinesText.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadNextLine);
            bw.RunWorkerAsync();
        }
        
        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Value = 0;
            foreach (string line in lines)
            {
                var split = lines[currentLine].Split(',');
                for (int i = 0; i < split.Length; i++)
                {
                    IEnumerable<VideoInfo> videolar = DownloadUrlResolver.GetDownloadUrls(split[i]);
                    VideoInfo video = videolar.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == Convert.ToInt32(comboBox1.Text));
                    if (video.RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(video);
                    }
                    VideoDownloader downloader = new VideoDownloader(video, Path.Combine(Application.StartupPath + "\\ " + video.Title + GetSafeFileName(video.Title, '_') + video.VideoExtension));
                    downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
                    downloader.Execute();
                }
            }
        }
        public void DownloadNextLine(object sender, RunWorkerCompletedEventArgs e)
        {
            currentLine++;
            if (currentLine == lines.Length - 1)
                return;
            bw.RunWorkerAsync();
        }
