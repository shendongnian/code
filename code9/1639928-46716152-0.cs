                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = ConfigurationManager.AppSettings["FTP.HOSTNAME"],
                    UserName = ConfigurationManager.AppSettings["FTP.USERNAME"],
                    Password = ConfigurationManager.AppSettings["FTP.PASSWORD"],
                };
                if (port.HasValue)
                {
                    sessionOptions.PortNumber = port.Value;
                }
                if (ShouldUseSSL())
                {
                    sessionOptions.SshHostKeyFingerprint = ConfigurationManager.AppSettings["FTP.CERT.FINGERPRINT"].Trim();
                }
    
                using (Session session = new Session())
                {
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["LOG.PATH"]))
                    {
                        session.SessionLogPath = ConfigurationManager.AppSettings["LOG.PATH"];
                    }
                    session.Open(sessionOptions);
                    TransferOptions transferOptions = new TransferOptions
                    {
                        TransferMode = TransferMode.Binary
                    };
    
                    TransferOperationResult transferResult = session.PutFiles(ConfigurationManager.AppSettings["FILE.TO.UPLOAD"], ConfigurationManager.AppSettings["FILE.DESTINATION.NAME"], true, transferOptions);
    
                    transferResult.Check();
    
                    StringBuilder result = new StringBuilder();
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        result.Append(string.Format("Upload of {0} : {1}", transfer.FileName, transfer.Error));
                    }
                    Console.WriteLine(result.ToString());
                }
