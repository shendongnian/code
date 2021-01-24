        public string TestingSSL(string sessionId)
        {
            TcpClient client = new TcpClient("name of the server", port);
            //Create certificate
            var collection = new X509Certificate2Collection();
           
            var certificate = new X509Certificate2("provided.pfx", "Passwordyouchoosewhencreatingthe.pfx", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
            collection.Add(certificate);
            const SslProtocols allowedProtocols = SslProtocols.Tls12 | SslProtocols.Tls11;
            // Create an SSL stream that will close the client's stream.
            SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificateTrue), null);
            // The server name must match the name on the server certificate.
            try
            {
                sslStream.AuthenticateAsClient("name of the server", collection, allowedProtocols, checkCertificateRevocation: true);
            }
            catch (AuthenticationException e)
            {
                if (e.InnerException != null)
                {
                    return e.InnerException.ToString();
                }
            }
            // Read message from the server.
            string serverMessage = ServerResponseMessage(sslStream);
            byte[] sessionBill = Encoding.UTF8.GetBytes("sessions.bill\r\n");
            byte[] sessionBillId = Encoding.UTF8.GetBytes($",session_uuid,{sessionId}\r\n");
            // Send command to the server. 
            sslStream.Write(sessionBill, 0, sessionBill.Length);
            sslStream.Flush();
            sslStream.Write(sessionBillId, 0, sessionBillId.Length);
            sslStream.Flush();
            string sessionBillResponseMessage = ServerResponseMessage(sslStream);
            // Close the client connection.
            client.Close();
            return sessionBillResponseMessage;
        }
        public static bool ValidateServerCertificateTrue(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        static string ServerResponseMessage(SslStream sslStream)
        {     
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            // Use Decoder class to convert from bytes to UTF8
            // in case a character spans two buffers.
            Decoder decoder = Encoding.UTF8.GetDecoder();
            char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
            decoder.GetChars(buffer, 0, bytes, chars, 0);
            messageData.Append(chars);     
            return messageData.ToString();
        }
