        public void DownloadFile(string str_target_dir)
        {
            using (var client = new SftpClient(host, user, pass))
            {
                client.Connect();
                var file = client.ListDirectory(_pacRemoteDirectory).FirstOrDefault(f => f.Name == "Name");
                if (file != null)
                {
                    using (Stream fileStream = File.OpenWrite(Path.Combine(str_target_dir, file.Name)))
                    {
                        client.DownloadFile(file.FullName, fileStream);
                    }
                }
                else
                {
                    //...
                }
            }
        }
