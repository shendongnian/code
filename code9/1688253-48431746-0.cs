     public Task Write(IEnumerable<FileInfo> files)
        {
            return Task.Run(() =>
            {
                using (var sftp = new SftpClient(this.sshInfo))
                {
                    sftp.Connect();
                    sftp.ChangeDirectory(this.remoteDirectory);
                    foreach (var file in files)
                    {
                        var parts = Path.GetDirectoryName(file.RelativePath)
                            .Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
                        sftp.ChangeDirectory(this.remoteDirectory);
                        foreach (var p in parts)
                        {
                            try
                            {
                                sftp.ChangeDirectory(p);
                            }
                            catch (SftpPathNotFoundException)
                            {
                                sftp.CreateDirectory(p);
                                sftp.ChangeDirectory(p);
                            }
                        }
                        sftp.UploadFile(file.Content, Path.GetFileName(file.RelativePath));
                    }
                }
            });
        }
