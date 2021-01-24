        using Renci.SshNet;
        public static void UploadSFTPFile()
        {
            _SftpDetails = ReadIniFile(IniFilePath, "Sftp_Settings", SftpDetails);
            string sourcefile = System.IO.Path.Combine(filepath, filename);
            string destinationpath = _SftpDetails["SftpDestinationFolder"];
            string host = _SftpDetails["Host"];
            string username = _SftpDetails["UserName"];
            string password = _SftpDetails["Password"];
            int port = Convert.ToInt32(_SftpDetails["Port"]);  //Port 22 is defaulted for SFTP upload
            try
            {
                using (SftpClient client = new SftpClient(host, port, username, password))
                {
                    client.Connect();
                    client.ChangeDirectory(destinationpath);
                    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fs, Path.GetFileName(sourcefile));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return;
            }
        }
