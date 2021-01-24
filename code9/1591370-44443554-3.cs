    private void button1_Click(object sender, EventArgs e)
    {
        // Run Download on background thread
        Task.Run(() => Download());
    }
    private void Download()
    {
        try
        {
            int Port = 22;
            string Host = "example.com";
            string Username = "username";
            string Password = "password";
            string RemotePath = "/remote/path/";
            string SourcePath = @"C:\local\path\";
            string FileName = "download.txt";
            using (var stream = new FileStream(SourcePath + FileName, FileMode.Create))
            using (var client = new SftpClient(Host, Port, Username, Password))
            {
                client.Connect();
                SftpFileAttributes attributes = client.GetAttributes(RemotePath + FileName);
                // Set progress bar maximum on foreground thread
                progressBar1.Invoke(
                    (MethodInvoker)delegate { progressBar1.Maximum = (int)attributes.Size; });
                // Download with progress callback
                client.DownloadFile(RemotePath + FileName, stream, DownloadProgresBar);
                MessageBox.Show("Download complete");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    private void DownloadProgresBar(ulong uploaded)
    {
        // Update progress bar on foreground thread
        progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = (int)uploaded; });
    }
