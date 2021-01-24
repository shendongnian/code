            FtpClient fclient = new FtpClient(hostname, username, password); // or set Host & Credentials
            fclient.EncryptionMode = FtpEncryptionMode.Implicit;  
            fclient.SslProtocols = SslProtocols.Tls12;
           
            //client.Port = 990;  // Not required - probably gives you exceptions if you try to set it. 
         
            fclient.Connect();
            fclient.UploadFile(@"C:\tmp\a.txt", "big.txt");
            
