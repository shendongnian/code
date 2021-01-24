    // async event handler
    private async void btn_Click(object sender, EventArgs e)
    {
        // async call to all the ips
        var results = await PingAsync(new List<string> { IP1, IP2, IP3, IP4, IP5 });
        // here we do not need the Dispatcher as await will restore UI context for you
       PingCompleted(results[0], img_m);
       // etc
    }
    private void PingCompleted(PingReply r, MediaTypeNames.Image img)
    {
        string imageAddress;
        if (r.Status == IPStatus.Success)
        {
            imageAddress = "subonline.gif";
        }
        else
        {
            imageAddress = "suboffline.gif";
        }
        var image = new BitmapImage();
        image.BeginInit();
        image.UriSource = new Uri(imageAddress, UriKind.Relative);
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.EndInit();
        ImageBehavior.SetAnimatedSource(img, image);
    }
    // helper method
    private async Task<PingReply[]> PingAsync(List<string> theListOfIPs)
    {
        Ping pingSender = new Ping();
        var tasks = theListOfIPs.Select(ip => pingSender.SendPingAsync(ip, 1000, new byte[5]));
        return await Task.WhenAll(tasks);
    }
