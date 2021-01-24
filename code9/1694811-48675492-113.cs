    TlsInfo TLSInfo;
    IPHostEntry DnsHost = await Dns.GetHostEntryAsync(HostURI.Host);
    using (TcpClient client = new TcpClient(DnsHost.HostName, 443))
    {
        using (SslStream sslstream = new SslStream(client.GetStream(), false, 
                                                   TlsValidationCallback, null))
        {
            sslstream.AuthenticateAsClient(DnsHost.HostName, null, 
                                          (SslProtocols)ServicePointManager.SecurityProtocol, false);
            TLSInfo = new TlsInfo(sslstream);
        }
    }
    //The HttpWebRequest goes on from here.
    HttpWebRequest httpRequest = WebRequest.CreateHttp(HostURI);
    //(...)
