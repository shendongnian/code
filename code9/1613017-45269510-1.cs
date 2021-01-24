    private void button1_Click(object sender, EventArgs e)
    {
        // Run Download on background thread
        Task.Run(() => Download());
    }
    private void Download()
    {
        try
        {
            const string url = "ftp://ftp.example.com/remote/path/file.zip";
            NetworkCredential credentials = new NetworkCredential("username", "password");
            // Query size of the file to be downloaded
            FtpWebRequest sizeRequest = (FtpWebRequest)WebRequest.Create(url);
            sizeRequest.Credentials = credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            long size = sizeRequest.GetResponse().ContentLength;
            progressBar1.Invoke(
                (MethodInvoker)delegate { progressBar1.Maximum = (int)size; });
            
            // Download the file
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = credentials;
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            using (Stream ftpStream = request.GetResponse().GetResponseStream())
            using (Stream fileStream = File.Create(@"C:\local\path\file.zip"))
            {
                byte[] buffer = new byte[10240];
                int read;
                int total = 0;
                while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, read);
                    total += read;
                    progressBar1.Invoke(
                        (MethodInvoker)delegate { progressBar1.Value = total; });
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
