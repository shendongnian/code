    TlsInfo tlsInfo = null;
    IPHostEntry dnsHost = await Dns.GetHostEntryAsync(HostURI.Host);
    using (TcpClient client = new TcpClient(dnsHost.HostName, 443))
    {
        using (SslStream sslStream = new SslStream(client.GetStream(), false, 
                                                   TlsValidationCallback, null))
        {
            sslstream.AuthenticateAsClient(dnsHost.HostName, null, 
                                          (SslProtocols)ServicePointManager.SecurityProtocol, false);
            tlsInfo = new TlsInfo(sslStream);
        }
    }
    //The HttpWebRequest goes on from here.
    HttpWebRequest httpRequest = WebRequest.CreateHttp(HostURI);
    //(...)
