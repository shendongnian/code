    void workerDOWN_DoWork(object sender, DoWorkEventArgs e)
            {
                string fileFullPath = e.Argument as String;
                string fileName = Path.GetFileName(fileFullPath);
                string fileExtension = Path.GetExtension(fileName);
     
                label4.Invoke((MethodInvoker)delegate { label4.Text = "Downloading File.."; });
    
                //FTP Download und Delete
                string ftpServerIP = "XXX";
                string ftpUserName = "XXXX";
                string ftpPassword = "XXXXX";
    
                try
                {
                    // dummy download ftp connection for ftp server bug
                    FtpWebRequest DummyRequest = (FtpWebRequest)WebRequest.Create(("ftp://" + ftpServerIP + "/anyfile"));
                    DummyRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                    DummyRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    using (Stream ftpStream = DummyRequest.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(Path.GetDirectoryName(Application.ExecutablePath) + "\\anyfile"))
                    {
                        ftpStream.CopyTo(fileStream);
                    }
                    //delete downloaded test file
                    File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\anyfile");
    
                    // Query size of the file to be downloaded
                    FtpWebRequest sizeRequest = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + "/" + fileName);
                    sizeRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                    sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                    var fileSize = sizeRequest.GetResponse().ContentLength;
    
                    //file download
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + "/" + fileName);
                    request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    using (Stream ftpStream = request.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(fileFullPath))
                    {
                        var buffer = new byte[32 * 1024];
                        int totalReadBytesCount = 0;
                        int readBytesCount;
                        while ((readBytesCount = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, readBytesCount);
                            totalReadBytesCount += readBytesCount;
                            var progress = (int)((float)totalReadBytesCount / (float)fileSize * 100);
                            workerDOWN.ReportProgress((int)progress);
                            label3.Invoke((MethodInvoker)delegate { label3.Text = progress + " %"; });
                        }
                    }
    
                    // delete file on ftp server
                    FtpWebRequest Delrequest = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + "/" + fileName);
                    Delrequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                    Delrequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse Delresponse = (FtpWebResponse)Delrequest.GetResponse();
                    Delresponse.Close();
    
                    // message file deleted
                    richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.AppendText("System: " + fileName + " wurde auf dem Server gelöscht." + Environment.NewLine); });
        
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
    
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        
                        MessageBox.Show("Datei nicht gefunden!", "Error");
                    } 
                }
    
                e.Result = fileFullPath;
                   
            }
    
    
            void workerDOWN_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar1.Value = e.ProgressPercentage;
            }
    
            void workerDOWN_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                 string fileFullPath = e.Result as String;
                 string fileName = Path.GetFileName(fileFullPath);
    
                 MessageBox.Show("Download erfolgreich!","Information");
    
                 progressBar1.Value = 0;
                 label3.Invoke((MethodInvoker)delegate { label3.Text = " "; });
                 label4.Invoke((MethodInvoker)delegate { label4.Text = " "; });
    
                 
            }
