     public async void GetDataCache(object sender, EventArgs e)
     {
        var loaded = await BlobCache.LocalMachine.GetObject<CachedUsers>("usercached");
        txtemail.Text = loaded.FullName;
        txtfullname.Text = loaded.FullName.ToString();
     }
