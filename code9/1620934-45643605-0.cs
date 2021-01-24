     void DownloadFile()
    {
        loadingBar.gameObject.SetActive(true);
        downloadButton.SetActive(false);
        downloadingFile = true;
        WebClient client = new WebClient();
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
        client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
        client.DownloadFileAsync(new Uri(url), Application.persistentDataPath + "/" + fileName);
    }
    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        double bytesIn = double.Parse(e.BytesReceived.ToString());
        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        double percentage = bytesIn / totalBytes * 100;
        downloadProgressText = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
        downloadProgress = int.Parse(Math.Truncate(percentage).ToString());
        totalBytes = e.TotalBytesToReceive;
        bytesDownloaded = e.BytesReceived;
    }
    void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            AllDone();
        }
    }
    void AllDone()
    {
        Debug.Log("File Downloaded");
        FileExists = 1;
    }
    public void DeleteVideo()
    {
        print("Delete File");
        PlayerPrefs.DeleteKey("videoDownloaded");
        FileExists = 0;
        enterButton.SetActive(false);
        downloadButton.SetActive(true);
        File.Delete(Application.persistentDataPath + "/" + fileName);
    }
