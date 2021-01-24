    private void button1_Click(object sender, EventArgs e)
    {
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
                progressBar1.Invoke(
                    (MethodInvoker)delegate { progressBar1.Maximum = (int)stream.Length; });
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
        progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = (int)uploaded; });
    }
