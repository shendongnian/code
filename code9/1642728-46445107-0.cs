    private async Task DoMyDownloading()
    {
      WebClient client = new WebClient();
      Process.Text("", "Downloading video data...", "new");
      await client.DownloadFileAsync(new Uri(this.VidLink), this.path + "\\tempVid"); // Line3
      Process.Text("", "Downloading audio data...", "old");
      await client.DownloadFileAsync(new Uri(this.AudLink), this.path + "\\tempAud"); // Line5
    
      FFMpegConverter merge = new FFMpegConverter();
      merge.Invoke(String.Format("-i \"{0}\\tempVid\" -i \"{1}\\tempAud\" -c copy \"{2}{3}\"", this.path, this.path, dir, filename)); // Line8
      merge.Stop();
      Process.Text("", "Video merging complete", "new");
    }
