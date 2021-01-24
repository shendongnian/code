    public async void Button1_Click()
    {
        var image = await connector.DownloadJPGAsync();
        pictureBox1.Image = image;
    }
