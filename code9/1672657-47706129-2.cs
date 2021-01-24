    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
    foreach(var pic in pics)
    {
        Task.Factory.StartNew(Object state =>
        {
            var data = (dynamic)state;
            Int32 id = (Int32)state.Id;
            Picture picture = (Picture)state.Picture;
            client.DownloadFile(new Uri(picture.Attributes[cmbAttr.Text].Value), folder + "\\" + id.ToString() + ".jpg")
        }, new { Id = picid, Picture = pic });
        ++picid;
    }
