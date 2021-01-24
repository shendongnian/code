     string host = @"host";
            string username = "user";
            string password = "pass";
            string remoteDirectory = "/remote";
          
            string localDirectory = Server.MapPath(@"\pdf\");
            using (var sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(remoteDirectory);
                foreach (var file in files)
                {
                    string remoteFileName = file.Name;
                    if (remoteFileName == "APADEAATTT.csv")
                    {
                        using (Stream file1 = File.OpenWrite(localDirectory + "APADEAATTT.csv"))
                        {
                            sftp.DownloadFile(remoteDirectory + "APADEAATTT.csv", file1);
                        }
                    }
                }
            }
            FileInfo fileInfo = new FileInfo(localDirectory+"APADEAATTT.csv");
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.ContentType = "text/csv";
            Response.Flush();
            Response.WriteFile(fileInfo.FullName);
            Response.End();
