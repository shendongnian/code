                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPURL);
                request.Credentials = new NetworkCredential(FTPUsername, FTPPassword);
                //Only required for SFTP
                //request.EnableSsl = true;
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                List<ListDirectoryDetailsOutput> directories = new List<ListDirectoryDetailsOutput>();
                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(new ListDirectoryDetailsOutput(line));
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
