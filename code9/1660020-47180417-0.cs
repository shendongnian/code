    async void DownloadLC_Normal_Button_Click(object sender, EventArgs e)
    {
        DownloadLC_Normal_CircleProgressBar.animated = true;
        DownloadLC_Normal_Button.Enabled = false; // prevent further clicks
        await Task.Run(() =>
        {
            ...  // long running code, use `Invoke` to update UI controls
        });
        DownloadLC_Normal_CircleProgressBar.animated = false;
        DownloadLC_Normal_Button.Enabled = true;
    }
