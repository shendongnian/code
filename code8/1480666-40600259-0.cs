    void Extract()
    {
        string zipPath = @"Repack.zip";
        string extractPath = @".";
        try
        {
            using (ZipFile unzip = ZipFile.Read(zipPath))
            {
                unzip.ExtractAll(extractPath);
                lbldlstatus.Text = "Extracting Files";
                MoveFiles();               
            }
        }
        catch (ZipException e)
        {
            MessageBox.Show(e.ToString());
            lbldlstatus.Text = "Repack Installation Failed";
        }
    }
