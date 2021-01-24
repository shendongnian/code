    public void favicon()
    {
            WebClient wc = new WebClient();
            MemoryStream memorystream = new MemoryStream(wc.DownloadData("http://" + new Uri(getCurrentBrowser().Address.ToString()).Host + "/favicon.ico"));
            Icon icon = new Icon(memorystream);
            string i = Convert.ToString(myimg.Images.Count);
            myimg.Images.Add(i, icon.ToBitmap());
            tabControl.ImageList = myimg;
            tabControl.SelectedTab.ImageIndex = myimg.Images.Count - 1;
    }
