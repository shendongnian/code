    public static void q48873455()
    {
    	const string hostname = "localhost";
    	var tcpClient = new TcpClient();
    	tcpClient.Connect(hostname, 443);
    	var tcpStream = tcpClient.GetStream();
    	
    	using (var sslStream = new SslStream(tcpStream, false, ValidateServerCertificate))
    	{
    		sslStream.AuthenticateAsClient(hostname);
    	}
    }
    
    
    static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
       if (sslPolicyErrors == SslPolicyErrors.None)
    		return true;
    
    	Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
    
    	return false;
    }
