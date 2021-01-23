    using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "select your path ." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string link = textBox1.Text;
                    IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);
                    VideoInfo video = videoInfos
                        .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);
                    if (video.RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(video);
                    }
                 
                    var videoDownloader = new VideoDownloader(video, fbd.SelectedPath + video.Title);
                    videoDownloader.DownloadProgressChanged += (sender1, args) => progressBar1.Value = (int)args.ProgressPercentage;
                    videoDownloader.Execute();
                }
            }
