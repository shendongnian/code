    private void button1_Click(object sender, EventArgs e)
    {
        // Run Upload on background thread
        Task.Run(() => Upload());
    }
    private void Upload()
    {
        try
        {
            int Port = 22;
            string Host = "example.com";
            string Username = "username";
            string Password = "password";
            string RemotePath = "/remote/path/";
            string SourcePath = @"C:\local\path\";
            string FileName = "upload.txt";
            using (var stream = new FileStream(SourcePath + FileName, FileMode.Open))
            using (var client = new SftpClient(Host, Port, Username, Password))
            {
                client.Connect();
                // Set progress bar maximum on foreground thread
                progressBar1.Invoke(
                    (MethodInvoker)delegate { progressBar1.Maximum = (int)stream.Length; });
                // Upload with progress callback
                client.UploadFile(stream, RemotePath + FileName, UpdateProgresBar);
                MessageBox.Show("Upload complete");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    private void UpdateProgresBar(ulong uploaded)
    {
        // Update progress bar on foreground thread
        progressBar1.Invoke(
            (MethodInvoker)delegate { progressBar1.Value = (int)uploaded; });
    }
