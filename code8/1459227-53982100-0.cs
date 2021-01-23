     // Client
            var client = new YoutubeClient();
            var videoId = NormalizeVideoId(txtFileURL.Text);
            var video = await client.GetVideoAsync(videoId);
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
            // Get the best muxed stream
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            // Compose file name, based on metadata
            var fileExtension = streamInfo.Container.GetFileExtension();
            var fileName = $"{video.Title}.{fileExtension}";
            // Replace illegal characters in file name
            fileName = RemoveIllegalFileNameChars(fileName);
            tmrVideo.Enabled = true;
            // Download video
            txtMessages.Text = "Downloading Video please wait ... ";
            //using (var progress = new ProgressBar())
            await client.DownloadMediaStreamAsync(streamInfo, fileName);
            // Add Nuget package: https://www.nuget.org/packages/NReco.VideoConverter/ To Convert MP4 to MP3
            if (ckbAudioOnly.Checked)
            {
                var Convert = new NReco.VideoConverter.FFMpegConverter();
                String SaveMP3File = MP3FolderPath + fileName.Replace(".mp4", ".mp3");
                Convert.ConvertMedia(fileName, SaveMP3File, "mp3");
                //Delete the MP4 file after conversion
                File.Delete(fileName);
                LoadMP3Files();
                txtMessages.Text = "File Converted to MP3";
                tmrVideo.Enabled = false;
                txtMessages.BackColor = Color.White;
                if (ckbAutoPlay.Checked) { PlayFile(SaveMP3File); }
                return;
            }
