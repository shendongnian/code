    private Image GetImage(string ImageLocation)
    {
        byte[] data = null;
        using (CustomWebClient WC = new CustomWebClient())
        {
            WC.Headers.Add(System.Net.HttpRequestHeader.UserAgent, "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0_1 like Mac OS X) AppleWebKit/601.1 (KHTML, like Gecko) CriOS/53.0.2785.109 Mobile/14A403 Safari/601.1.46");
            WC.Headers.Add(System.Net.HttpRequestHeader.Cookie, "cf_clearance=" + PhantomObject.Manage().Cookies.GetCookieNamed("cf_clearance").Value);
            data = WC.DownloadData(ImageLocation);
        }
        Bitmap MP = new Bitmap(new System.IO.MemoryStream(data));
        data = null;
        return MP;
    }
