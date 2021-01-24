    //try this , 
    
    var cl = new FtpClient(Server, Port, User, Password);
                cl.EncryptionMode = FtpEncryptionMode.Implicit;
                cl.DataConnectionType = FtpDataConnectionType.AutoPassive;
                cl.DataConnectionEncryption = true;
                cl.SslProtocols = protocol;
                cl.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
                var cer = new X509Certificate2(certificate);
                cl.ClientCertificates.Add(cer);
     System.Net.ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
     client.Connect();
    
    
     void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
            {
                // add logic to test if certificate is valid here
                e.Accept = true;
            }
            private  bool ServerCertificateValidationCallback(object sender,
                                                    X509Certificate certificate,
                                                    X509Chain chain,
                                                    SslPolicyErrors sslPolicyErrors)
            {
                return true;
            } 
