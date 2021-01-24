    private void ping(string IP, MediaTypeNames.Image img)
    {
        Ping p = new Ping();
        PingReply r;
        // lambda delegate here, may use event handler instead
        p.PingCompleted += (sender, args) => { PingCompleted(args, img); };
        r = p.SendAsync(IP, 1000, new byte[5], null);
    }
    private void PingCompleted(PingCompletedEventArgs args, MediaTypeNames.Image img)
    {
        this.Dispatcher.Invoke(() =>
            {
                string imageAddress;
                if (args.Reply.Status == IPStatus.Success)
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
            });
    }
