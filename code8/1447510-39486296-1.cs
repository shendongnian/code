    Thread youtubeDownloader = new Thread(delegate () 
            {
                FolderBrowserDialog b = new FolderBrowserDialog();
                this.Invoke((MethodInvoker)delegate () { if (b.ShowDialog() != DialogResult.OK) return;  });
                    {
                        string link = textBox1.Text;
                        IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);
                        VideoInfo video = videoInfos
                            .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);
                        if (video.RequiresDecryption)
                        {
                            DownloadUrlResolver.DecryptDownloadUrl(video);
                        }
                        var videoDownloader = new VideoDownloader(video, b.SelectedPath + video.Title);
                        videoDownloader.DownloadProgressChanged += (sender1, args) => this.Invoke((MethodInvoker)delegate () { progressBar1.Value = (int)args.ProgressPercentage;});
                        videoDownloader.Execute();
                    }
                
            });
            youtubeDownloader.IsBackground = true;
            youtubeDownloader.Start();
