    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
    foreach(var pic in pics)
    {
        Task.Factory.StartNew(Object state =>
        {
            Int32 offset = (Int32)state;
            client.DownloadFile(new Uri(pic.Attributes[cmbAttr.Text].Value), folder + "\\" + picid.ToString() + ".jpg")
        }, picid);
        ++picid;
    }
