     string[] lines = YourAllLinesText.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
     foreach(string line in lines)
     {
       var split = txtURL.Text.Split(',');
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
                    Thread thread = new Thread(() => { downloader.Execute(); }) { IsBackground = true };
                    thread.Start();
                }
      }
